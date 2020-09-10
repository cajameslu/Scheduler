Imports System.IO
Imports System.Xml

Public Class DataLoader

	Public Const DATE_SAVE_FORMAT As String = "yyyy-MM-dd"

	Private _scheduler As Scheduler

	Public Sub New(scheduler As Scheduler)
		_scheduler = scheduler
	End Sub

	Public Function SaveData(fileName As String) As Boolean
		Try
			Using fs As New FileStream(fileName, FileMode.Create, FileAccess.Write)
				Dim ws As New XmlWriterSettings()
				ws.Indent = True
				Using writer As XmlWriter = XmlWriter.Create(fs, ws)
					SaveDataXml(writer)
				End Using
			End Using

			Return True
		Catch ex As Exception
			MsgBox("Failed to save data: " & ex.Message)

			Return False
		End Try
	End Function

	Private Sub SaveDataXml(writer As XmlWriter)
		writer.WriteStartElement("Data")

		SaveStatisticStartDate(writer)
        SaveResourceCategories(writer)
        SaveDefaultResourceCategory(writer)
        SaveResources(writer)
		SaveDays(writer)

		writer.WriteEndElement()
	End Sub

	Public Sub SaveStatisticStartDate(writer As XmlWriter)
		writer.WriteStartElement("StatisticStartDate")
		writer.WriteString(_scheduler.StatisticStartDate.ToString(DATE_SAVE_FORMAT))
		writer.WriteEndElement()
	End Sub

	Private Sub SaveResourceCategories(writer As XmlWriter)
		writer.WriteStartElement("ResourceCategories")
		For Each rc As ResourceCategory In _scheduler.AllResourceCategory
			SaveResourceCategory(writer, rc)
		Next

		writer.WriteEndElement()
	End Sub

    Public Sub SaveResourceCategory(writer As XmlWriter, rc As ResourceCategory)
        writer.WriteStartElement("ResourceCategory")

        writer.WriteStartElement("Name")
        writer.WriteString(rc.Name)
        writer.WriteEndElement()

        writer.WriteStartElement("Color")
        writer.WriteString(rc.Color.ToArgb)
        writer.WriteEndElement()

        writer.WriteEndElement()
    End Sub

    Public Sub SaveDefaultResourceCategory(writer As XmlWriter)
        If _scheduler.DefaultResourceCategory IsNot Nothing Then
            writer.WriteStartElement("DefaultResourceCategory")
            writer.WriteString(_scheduler.DefaultResourceCategory.Name)
            writer.WriteEndElement()
        End If
    End Sub

    Private Sub SaveResources(writer As XmlWriter)
		writer.WriteStartElement("Resources")
		For Each p As Resource In _scheduler.AllResource
			SaveResource(writer, p)
		Next

		writer.WriteEndElement()
	End Sub

	Public Sub SaveResource(writer As XmlWriter, p As Resource)
		writer.WriteStartElement("Resource")

		writer.WriteStartElement("Name")
		writer.WriteString(p.Name)
		writer.WriteEndElement()

		writer.WriteStartElement("Notes")
		writer.WriteString(p.Notes)
		writer.WriteEndElement()

		writer.WriteStartElement("Active")
		writer.WriteValue(p.Active)
		writer.WriteEndElement()

		writer.WriteStartElement("ResourceCategory")
		writer.WriteValue(p.ResourceCategory.Name)
		writer.WriteEndElement()

		writer.WriteStartElement("StartDate")
		writer.WriteString(p.StartDate.ToString(DATE_SAVE_FORMAT))
		writer.WriteEndElement()

		writer.WriteEndElement()
	End Sub

	Private Sub SaveDays(writer As XmlWriter)
		writer.WriteStartElement("Days")
		For Each d As Day In _scheduler.AllDays
			'No point to save the day if no resource scheduled
			If d.Resources.Count > 0 Then
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

		For Each p As Resource In d.Resources
			writer.WriteStartElement("Resource")
			writer.WriteString(p.Name)
			writer.WriteEndElement()
		Next

		writer.WriteEndElement()
	End Sub

	Public Function LoadData(fileName As String) As Boolean
		Try
			Using fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
				Dim rs As New XmlReaderSettings()
				rs.IgnoreWhitespace = True
				rs.IgnoreComments = True
				Using reader As XmlReader = XmlReader.Create(fs, rs)
					LoadDataXml(reader)
				End Using
			End Using

			Return True
		Catch ex As Exception
			MsgBox("Failed to load data: " & ex.Message)

			Return False
		End Try
	End Function

	Private Sub LoadDataXml(reader As XmlReader)
		While reader.Read()
			Select Case reader.NodeType
				Case XmlNodeType.Element
					If Not reader.IsEmptyElement Then
                        If reader.Name = "StatisticStartDate" Then
                            LoadStatisticStartDate(reader)
                        ElseIf reader.Name = "ResourceCategories" Then
                            LoadResourceCategories(reader)
                        ElseIf reader.Name = "DefaultResourceCategory" Then
                            LoadDefaultCategory(reader)
                        ElseIf reader.Name = "Resources" Then
							LoadResources(reader)
						ElseIf reader.Name = "Days" Then
							LoadDays(reader)
						End If
					End If


					'Case XmlNodeType.Text

					'Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction

					'Case XmlNodeType.Comment

					'Case XmlNodeType.EndElement

			End Select
		End While
	End Sub

	Private Sub LoadStatisticStartDate(reader As XmlReader)
		While reader.Read()
			Select Case reader.NodeType
				Case XmlNodeType.Text
					_scheduler.StatisticStartDate = Date.ParseExact(reader.Value, DATE_SAVE_FORMAT, System.Globalization.DateTimeFormatInfo.InvariantInfo)

					'Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction

					'Case XmlNodeType.Comment

				Case XmlNodeType.EndElement
					If reader.Name = "StatisticStartDate" Then
						Return
					End If

			End Select
		End While
	End Sub

    Private Sub LoadResourceCategories(reader As XmlReader)
        Dim level As String = Nothing
        Dim resourceCate As ResourceCategory = Nothing

        While reader.Read()
            Select Case reader.NodeType
                Case XmlNodeType.Element
                    level = reader.Name
                    If reader.Name = "ResourceCategory" Then
                        resourceCate = New ResourceCategory()
                    End If

                Case XmlNodeType.Text
                    If level = "Name" Then
                        resourceCate.Name = reader.Value
                        _scheduler.AddResourceCategory(resourceCate)
                    ElseIf level = "Color" Then
                        resourceCate.Color = Color.FromArgb(reader.Value)
                    End If

                    'Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction

                    'Case XmlNodeType.Comment

                Case XmlNodeType.EndElement
                    If reader.Name = "ResourceCategories" Then
                        Return
                    End If

            End Select
        End While
    End Sub

    Private Sub LoadDefaultCategory(reader As XmlReader)
        While reader.Read()
            Select Case reader.NodeType
                Case XmlNodeType.Text
                    Dim rc As ResourceCategory = _scheduler.GetResourceCategoryByName(reader.Value)
                    _scheduler.DefaultResourceCategory = rc

                    'Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction

                    'Case XmlNodeType.Comment

                Case XmlNodeType.EndElement
                    If reader.Name = "DefaultResourceCategory" Then
                        Return
                    End If

            End Select
        End While
    End Sub

    Private Sub LoadResources(reader As XmlReader)
		Dim level As String = Nothing
		Dim resource As Resource = Nothing

		While reader.Read()
			Select Case reader.NodeType
				Case XmlNodeType.Element
					level = reader.Name
					If reader.Name = "Resource" Then
                        resource = New Resource(_scheduler)
                    End If

				Case XmlNodeType.Text
					If level = "Name" Then
						resource.Name = reader.Value
						_scheduler.AddResource(resource)
					ElseIf level = "Notes" Then
						resource.Notes = reader.Value
					ElseIf level = "Active" Then
						resource.Active = reader.ReadContentAsBoolean()
					ElseIf level = "StartDate" Then
						resource.StartDate = Date.ParseExact(reader.Value, DATE_SAVE_FORMAT, System.Globalization.DateTimeFormatInfo.InvariantInfo)
					ElseIf level = "ResourceCategory" Then
						resource.ResourceCategory = _scheduler.GetResourceCategoryByName(reader.Value)
					End If

					'Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction

					'Case XmlNodeType.Comment

				Case XmlNodeType.EndElement
					If reader.Name = "Resources" Then
						Return
					End If

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

				Case XmlNodeType.Text
					If level = "Date" Then
						day.SchedDate = reader.Value
						_scheduler.AddDay(day)
					ElseIf level = "Resource" Then
						If _scheduler.ContainsResource(reader.Value) Then
							day.AddResource(_scheduler.GetResourceByName(reader.Value))
						End If
					End If

					'Case XmlNodeType.XmlDeclaration, XmlNodeType.ProcessingInstruction

					'Case XmlNodeType.Comment

				Case XmlNodeType.EndElement
					If reader.Name = "Days" Then
						Return
					End If

			End Select
		End While
	End Sub


End Class
