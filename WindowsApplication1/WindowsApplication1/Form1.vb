Public Class Form1

    Public currentGUI As String
    Public Property ActiveSheet As Object

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        currentGUI = "GUIMain"
        drawGui(currentGUI)

        Console.WriteLine("Hello world")

    End Sub

    Public Sub drawBox(x As Int16, y As Int16, width As Int16, height As Int16, color As Color)

        Dim myBrush As New System.Drawing.SolidBrush(color)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.FillRectangle(myBrush, New Rectangle(x, y, width, height))
        myBrush.Dispose()
        formGraphics.Dispose()

    End Sub

    Public Sub drawBoxWithShadow(x As Int16, y As Int16, width As Int16, height As Int16, color As Color)

        drawBox(x - 2, y - 2, width + 4, height + 4, Color.FromArgb(40, 0, 0, 0))
        drawBox(x, y, width, height, color)

    End Sub

    Public Sub drawButton(x As Int16, y As Int16, width As Int16, height As Int16, color As Color, buttonName As String, identifier As String)

        'The Button Factory
        Dim newButton = New Button()
        newButton.Location = New Point(x, y)
        newButton.Text = buttonName

        newButton.Width = width
        newButton.Height = height
        newButton.Name = "guiButton" + identifier.ToString

        AddHandler newButton.Click, AddressOf ButtonClicked

        Me.Controls.Add(newButton)

        'Make Button Flat (To fit proper theme)
        newButton.FlatAppearance.BorderSize = 0
        newButton.BackColor = color
        newButton.FlatAppearance.MouseDownBackColor = color
        newButton.FlatAppearance.MouseOverBackColor = color
        newButton.FlatStyle = FlatStyle.Flat
        drawBoxWithShadow(x, y, width, height, color)

    End Sub

    Private Sub ButtonClicked(ByVal sender As Object, ByVal e As EventArgs)

        Console.WriteLine(sender.Name)


        Select Case sender.Name.ToString

            Case "guiButton0"
                currentGUI = "GUIMain"
                drawGui(currentGUI)

            Case "guiButton1"
                currentGUI = "GUISecond"
                drawGui(currentGUI)

        End Select

    End Sub

    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        drawGui(currentGUI)

    End Sub

    Public Sub drawGui(gui As String)

        'Width and Height of Screen (For adding Menu Elements)
        Dim screenWidth As Integer = Form.ActiveForm.ClientSize.Width
        Dim screenHeight As Integer = Form.ActiveForm.ClientSize.Height

        'Get Graphics Tool to clear screen
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.Clear(Color.White)

        'Remove all buttons from Menu (start fresh)
        Me.Controls.Clear()

        'Button Cases
        '0 - Main Menu
        '1 - Second Page

        Select Case gui

            Case "GUIMain"
                drawBoxWithShadow(0, 0, screenWidth, 40, Color.FromArgb(255, 51, 153, 255))
                drawBoxWithShadow(7, 48, screenWidth / 2 - 8, 30, Color.FromArgb(255, 51, 153, 255))
                drawBoxWithShadow(0, screenHeight - 40, screenWidth, 40, Color.FromArgb(255, 51, 153, 255))
                drawButton(10, 10, 120, 20, Color.FromArgb(255, 51, 153, 255), "Go to Second Page", 1)

            Case "GUISecond"
                drawBoxWithShadow(0, 0, screenWidth, 40, Color.FromArgb(51, 51, 153, 255))
                drawBoxWithShadow(7, 48, screenWidth / 2 - 8, 30, Color.FromArgb(51, 51, 153, 255))

                drawBoxWithShadow(0, screenHeight - 40, screenWidth, 40, Color.FromArgb(51, 51, 153, 255))
                drawButton(10, 10, 40, 120, Color.FromArgb(51, 51, 153, 255), "Back to Main Menu", 0)

        End Select

    End Sub

End Class
