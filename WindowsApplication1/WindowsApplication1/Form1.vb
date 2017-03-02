Public Class Form1

    Public currentGUI As String
    Public Property ActiveSheet As Object

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        currentGUI = "GUIMain"
        drawGui(currentGUI)

    End Sub

    'Add new colored box to menu
    'x - x coordinate of box
    'y - y coordinate of box
    'width - width of box
    'height - height of box
    'color - color of box
    Public Sub drawBox(x As Int16, y As Int16, width As Int16, height As Int16, color As Color)

        Dim myBrush As New System.Drawing.SolidBrush(color)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.FillRectangle(myBrush, New Rectangle(x, y, width, height))
        myBrush.Dispose()
        formGraphics.Dispose()

    End Sub

    'Add new colored box with shaded outline to menu
    'x - x coordinate of box
    'y - y coordinate of box
    'width - width of box
    'height - height of box
    'color - color of box
    Public Sub drawBoxWithShadow(x As Int16, y As Int16, width As Int16, height As Int16, color As Color)

        drawBox(x - 2, y - 2, width + 4, height + 4, Color.FromArgb(40, 0, 0, 0))
        drawBox(x, y, width, height, color)

    End Sub

    'Set background of menu with image
    'filePath - file path of image (Debug: /bin/debug/)
    Public Sub drawBackgroundImage(filePath As String)

        'Width and Height of Screen (For adding Menu Elements)
        Dim screenWidth As Integer = Form.ActiveForm.ClientSize.Width
        Dim screenHeight As Integer = Form.ActiveForm.ClientSize.Height

        Dim image As Image
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()

        image = Image.FromFile(filePath)

        formGraphics.DrawImage(image, 0, 0, screenWidth, screenHeight)

    End Sub

    'Add new image to menu
    'x - x coordinate of image
    'y - y coordinate of image
    'width - width of image
    'height - height of image
    'filePath - file path of image (Debug: /bin/debug/)
    Public Sub drawImage(x As Int16, y As Int16, width As Int16, height As Int16, filePath As String)

        Dim image As Image
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()

        image = Image.FromFile(filePath)

        formGraphics.DrawImage(image, x, y, width, height)

    End Sub

    'Add new image with outline to menu
    'x - x coordinate of image
    'y - y coordinate of image
    'width - width of image
    'height - height of image
    'filePath - file path of image (Debug: /bin/debug/)
    'color - outline color
    Public Sub drawImageWithOutline(x As Int16, y As Int16, width As Int16, height As Int16, filePath As String, color As Color)

        Dim image As Image
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()

        image = Image.FromFile(filePath)

        drawBox(x - 2, y - 2, width + 2, height + 2, color)
        formGraphics.DrawImage(image, x, y, width, height)

    End Sub

    'Draw Button - Add a new button to your Menu
    'x - x coordinate of button
    'y - y coordinate of button
    'width - width of button
    'height - height of button
    'color - color of button
    'buttonName - name displayed on button
    'identifier - ID of button (used for button functions)
    Public Sub drawButton(x As Int16, y As Int16, width As Int16, height As Int16, color As Color, buttonName As String, identifier As String)

        'The Button Factory
        Dim newButton = New Button()
        newButton.Location = New Point(x, y)
        newButton.Text = buttonName

        'Set width and height of button
        newButton.Width = width
        newButton.Height = height
        newButton.Name = "guiButton" + identifier.ToString

        'Handle this buttons click events
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

    'Button Clicked Event
    'Checks button id when clicked in order to distinguish which functions
    'to initiate. It's important that all buttons have a unique identifier
    '(hence I added an int for adding new buttons)
    Private Sub ButtonClicked(ByVal sender As Object, ByVal e As EventArgs)

        Console.WriteLine(sender.Name)

        'Get button name + id
        Select Case sender.Name.ToString

            'initial default example buttons
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

        'Current Menu's in example
        'GUIMain - Main menu
        'GUISecond - Second example menu

        'Check which gui is to initialize
        Select Case gui

            'INITIAL MENU - Do not delete unless you change value of "currentGui" string
            Case "GUIMain"
                drawBoxWithShadow(0, 0, screenWidth, 40, Color.FromArgb(255, 51, 153, 255))
                drawBoxWithShadow(7, 48, screenWidth / 2 - 8, 30, Color.FromArgb(255, 51, 153, 255))
                drawBoxWithShadow(0, screenHeight - 40, screenWidth, 40, Color.FromArgb(255, 51, 153, 255))
                drawButton(10, 10, 120, 20, Color.FromArgb(255, 51, 153, 255), "Go to Second Page", 1)

            'Second example menu with Image and Background
            Case "GUISecond"
                drawBackgroundImage("background.jpg")
                drawBoxWithShadow(0, 0, screenWidth, 40, Color.FromArgb(51, 51, 153, 255))
                drawBoxWithShadow(7, 48, screenWidth / 2 - 8, 30, Color.FromArgb(51, 51, 153, 255))
                drawBoxWithShadow(0, screenHeight - 40, screenWidth, 40, Color.FromArgb(51, 51, 153, 255))
                drawButton(10, 10, 40, 120, Color.FromArgb(51, 51, 153, 255), "Back to Main Menu", 0)
                drawImageWithOutline(50, 50, 300, 300, "example.jpeg", Color.Red)

        End Select

    End Sub

End Class
