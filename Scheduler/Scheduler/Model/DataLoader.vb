Imports System.IO
Imports System.Xml

Public Class DataLoader

	Private Const DATA_FILE As String = "Data.xml"

	Public Const DATE_SAVE_FORMAT As String = "yyyy-MM-dd"

	Private _scheduler As Scheduler

	Public Sub New(scheduler As Scheduler)
		_scheduler = scheduler
	End Sub

	Public Sub SaveData()
		Using fs As New FileStream(DATA_FILE, FileMode.Create, FileAccess.Write)
			Dim ws As New XmlWriterSettings()
			ws.Indent = True
			Using writer As XmlWriter = XmlWriter.Create(fs, ws)
				SaveDataXml(writer)
			End Using
		End Using
	End Sub

	Private Sub SaveDataXml(writer As XmlWriter)
		writer.WriteStartElement("Data")

		SavePersons(writer)
		SaveDays(writer)

		writer.WriteEndElement()
	End Sub

	Private Sub SavePersons(writer As XmlWriter)
        writer.WriteStartElement("Resources")
        For Each p As Resource In _scheduler.AllPersons
            SavePerson(writer, p)
        Next

        writer.WriteEndElement()
	End Sub

    Public Sub SavePerson(writer As XmlWriter, p As Resource)
        writer.WriteStartElement("Resource")

        writer.WriteStartElement("Name")
        writer.WriteString(p.Name)
        writer.WriteEndElement()

        writer.WriteStartElement("Active")
        writer.WriteValue(p.Active)
        writer.WriteEndElement()

        writer.WriteStartElement("StartDate")
        writer.WriteString(p.StartDate.ToString(DATE_SAVE_FORMAT))
        writer.WriteEndElement()

        writer.WriteEndElement()
    End Sub

    Private Sub SaveDays(writer As XmlWriter)
		writer.WriteStartElement("Days")
        For Each d As Day In _scheduler.AllDays
            'No point to save the day if no person scheduled
            If d.Persons.Count > 0 Then
                SaveDay(writer, d)
            End If
        Next

        writer.WriteEndElement()
	End Sub

	Public Sub SaveDay(writer As XmlWriter, d As Day)
		writer.WriteStartElement("Day")

		writer.WriteStartElement("Date")
		writer.WriteString(d.SchedDate.ToString(DATE_SAVE_FORMAT))
		writer.WriteEndElement()

        For Each p As Resource In d.Persons
            writer.WriteStartElement("Resource")
            writer.WriteString(p.Name)
            writer.WriteEndElement()
        Next

        writer.WriteEndElement()
	End Sub

	Public Sub LoadData()
		Using fs As New FileStream(DATA_FILE, FileMode.Open, FileAccess.Read)
			Dim rs As New XmlReaderSettings()
			rs.IgnoreWhitespace = True
			rs.IgnoreComments = True
			Using reader As XmlReader = XmlReader.Create(fs, rs)
				LoadDataXml(reader)
			End Using
		End Using
	End Sub

	Private Sub LoadDataXml(reader As XmlReader)
		While reader.Read()
			Select Case reader.NodeType
				Case XmlNodeType.Element
                    If reader.Name = "StatisticStartDate" Then
                        LoadStatisticStartDate(reader)
                    ElseIf reader.Name = "Resources" Then
                        LoadPersons(reader)
					ElseIf reader.Name = "Days" Then
						LoadDays(reader)
					End If

					Exit Select
				Case XmlNodeType.Text
					Exit Select
				Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction
					Exit Select
				Case XmlNodeType.Comment
					Exit Select
				Case XmlNodeType.EndElement
					Exit Select
			End Select
		End While
	End Sub

	Private Sub LoadStatisticStartDate(reader As XmlReader)
		While reader.Read()
			Select Case reader.NodeType
				Case XmlNodeType.Text
					_scheduler.StatisticStartDate = Date.ParseExact(reader.Value, DATE_SAVE_FORMAT, System.Globalization.DateTimeFormatInfo.InvariantInfo)
					Exit Select
				Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction
					Exit Select
				Case XmlNodeType.Comment
					Exit Select
				Case XmlNodeType.EndElement
					If reader.Name = "StatisticStartDate" Then
						Return
					End If
					Exit Select
			End Select
		End While
	End Sub

	Private Sub LoadPersons(reader As XmlReader)
		Dim level As String = Nothing
        Dim person As Resource = Nothing

        While reader.Read()
			Select Case reader.NodeType
				Case XmlNodeType.Element
					level = reader.Name
                    If reader.Name = "Resource" Then
                        person = New Resource(_scheduler)
                    End If
                    Exit Select
				Case XmlNodeType.Text
                    If level = "Name" Then
                        person.Name = reader.Value
                        _scheduler.AddPerson(person)
                    ElseIf level = "Active" Then
                        person.Active = reader.ReadContentAsBoolean()
                    ElseIf level = "StartDate" Then
						person.StartDate = Date.ParseExact(reader.Value, DATE_SAVE_FORMAT, System.Globalization.DateTimeFormatInfo.InvariantInfo)
					End If
					Exit Select
				Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction
					Exit Select
				Case XmlNodeType.Comment
					Exit Select
				Case XmlNodeType.EndElement
                    If reader.Name = "Resources" Then
                        Return
                    End If
                    Exit Select
			End Select
		End While
	End Sub

	Private Sub LoadDays(reader As XmlReader)
		Dim level As [String] = Nothing
		Dim day As Day = Nothing

		While reader.Read()
			Select Case reader.NodeType
				Case XmlNodeType.Element
					level = reader.Name
					If reader.Name = "Day" Then
						day = New Day()
					End If
					Exit Select
				Case XmlNodeType.Text
                    If level = "Date" Then
                        day.SchedDate = reader.Value
                        _scheduler.AddDay(day)
                    ElseIf level = "Resource" Then
                        If _scheduler.ContainsPerson(reader.Value) Then
							day.AddPerson(_scheduler.GetPersonByName(reader.Value))
						End If
					End If
					Exit Select
				Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction
					Exit Select
				Case XmlNodeType.Comment
					Exit Select
				Case XmlNodeType.EndElement
					If reader.Name = "Days" Then
						Return
					End If
					Exit Select
			End Select
		End While
	End Sub


End Class
