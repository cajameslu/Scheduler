Public Class LayoutGrid

    Protected _cellSize As Size
    Protected _colsPerRow As Integer

    Protected _cellOffSet As Integer
    Protected _cellsCount As Integer

    Protected _position As PointF
    Protected _size As Size
    Protected _effectiveSize As Size

    Public Sub New(colsPerRow As Integer)
        _colsPerRow = colsPerRow
    End Sub

    Public Property Position As PointF
        Get
            Return _position
        End Get
        Set(value As PointF)
            _position = value
        End Set
    End Property

    Public Property Size As Size
        Get
            Return _size
        End Get
        Set(value As Size)
            _size = value
        End Set
    End Property

    Public Property EffectiveSize As Size
        Get
            Return _effectiveSize
        End Get
        Set(value As Size)
            _effectiveSize = value
        End Set
    End Property

    Public Property CellsCount As Integer
        Get
            Return _cellsCount
        End Get
        Set(value As Integer)
            _cellsCount = value
        End Set
    End Property

    Public Property CellOffset As Integer
        Get
            Return _cellOffSet
        End Get
        Set(value As Integer)
            _cellOffSet = value
        End Set
    End Property

    Public Sub CalulateLayout()
        _effectiveSize = _size

        Dim hight As Single = _effectiveSize.Height
        Dim width As Single = _effectiveSize.Width

        Dim totalCellCnt As Integer = _cellOffSet + _cellsCount
        Dim _rows = Math.Ceiling(totalCellCnt / _colsPerRow)

        _cellSize.Width = _effectiveSize.Width / _colsPerRow
        _cellSize.Height = _effectiveSize.Height / _rows
    End Sub

    Public Function GetCellRectangle(i As Integer) As RectangleF
        Dim index As Integer = _cellOffSet + i
        Dim rowNo As Integer = Math.Floor(index / _colsPerRow)
        Dim colNo As Integer = index Mod _colsPerRow

        Dim x As Single = _position.X + _cellSize.Width * colNo
        Dim y As Single = _position.Y + _cellSize.Height * rowNo

        Return New RectangleF(x, y, _cellSize.Width, _cellSize.Height)
    End Function

End Class
