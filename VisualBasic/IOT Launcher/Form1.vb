Imports System
Imports System.IO
Imports System.IO.Directory

Public Class Form1

    Dim p() As Process

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'ckeck if InfluxDB is OK to RUN
        If Not My.Computer.FileSystem.FileExists("influxdb\influxd.exe") Then
            MessageBox.Show("InfluxDB files not found. Please ckeck!", "Process checking", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GoTo jump
        End If
        'ckeck if Node-RED is OK to RUN
        If Not My.Computer.FileSystem.FileExists("C:\Program Files\nodejs\node.exe") Then
            MessageBox.Show("Please install Node.js...", "Process checking", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Process.Start("https://nodejs.org/en/download/current/")
            GoTo jump
            If Not My.Computer.FileSystem.FileExists("node-red/node-red") Then
                MessageBox.Show("InfluxDB files not found. Please ckeck!", "Process checking", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                GoTo jump
            End If
        End If
        'ckeck if Grafana is OK to RUN
        If Not My.Computer.FileSystem.FileExists("grafana\bin\grafana-server.exe") Then
            MessageBox.Show("Grafana files not found. Please ckeck!", "Process checking", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GoTo jump
        End If
        'ckeck if Mosquitto is OK to RUN
        If Not My.Computer.FileSystem.FileExists("mosquitto/mosquitto.exe") Then
            MessageBox.Show("Mosquitto files not found. Please ckeck!", "Process checking", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GoTo jump
        End If

        'Clean Exit
jump:
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Process.Start("http://localhost:1880")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Process.Start("http://localhost:3000")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Mosquitto control-------------------------------------
        p = Process.GetProcessesByName("mosquitto")
        If p.Count > 0 Then
            ' Process is running-------get---STOP
            Shell("taskkill.exe /f /t /im mosquitto.exe")
            Button1.Image = My.Resources.mosquitto_mini_grey
            Label1.Text = "Mosquitto OFF"
        Else
            ' Process is not running---get---RUN
            Dim works As String
            works = "mosquitto\mosquitto.exe -v"
            Shell(works, AppWinStyle.MinimizedFocus)
            Button1.Image = My.Resources.mosquitto_mini
            Label1.Text = "Mosquitto Running"
        End If

    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Ckeck if process is running
        p = Process.GetProcessesByName("influxd")
        If p.Count > 0 Then
            ' Process is running
            Button4.Image = My.Resources.influxdb_mini
            Label2.Text = "InfluxDB is OK!"
        Else
            ' Process is not running
            Button4.Image = My.Resources.influxdb_mini_grey
            Label2.Text = "NOT RUNNING!"
        End If
        '_________________________________________________________________________
        p = Process.GetProcessesByName("node")
        If p.Count > 0 Then
            ' Process is running
            Button2.Image = My.Resources.node_red_mini
            Label3.Text = "Node-RED is OK!"
        Else
            ' Process is not running
            Button2.Image = My.Resources.node_red_mini_grey
            Label3.Text = "NOT RUNNING!"
        End If
        '_________________________________________________________________________
        p = Process.GetProcessesByName("grafana-server")
        If p.Count > 0 Then
            ' Process is running
            Button3.Image = My.Resources.grafana_mini
            Label4.Text = "Grafana is OK!"
        Else
            ' Process is not running
            Button3.Image = My.Resources.grafana_mini_grey
            Label4.Text = "NOT RUNNING!"
        End If
        '_________________________________________________________________________
        p = Process.GetProcessesByName("mosquitto")
        If p.Count > 0 Then
            ' Process is running
            Button1.Image = My.Resources.mosquitto_mini
            Label1.Text = "Mosquitto.exe is OK!"
        Else
            ' Process is not running
            Button1.Image = My.Resources.mosquitto_mini_grey
            Label1.Text = "NOT RUNNING!"
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        MessageBox.Show("InfluxDB = No credentials / Url: localhost:8086" &
                        Environment.NewLine & "" &
                        Environment.NewLine & "Grafana = admin admin / Url: localhost:3000" &
                        Environment.NewLine & "" &
                        Environment.NewLine & "Mosquitto = No credentials / Url: localhost:1883" &
                        Environment.NewLine & "" &
                        Environment.NewLine & "Node-RED = No credentials Url: localhost:1880",
                        " Default Login credentials.")

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

         'InfluxDB control-------------------------------------
        p = Process.GetProcessesByName("influxd")
        If p.Count > 0 Then
            ' Process is running-------get---STOP
            Shell("taskkill.exe /f /t /im influxd.exe")
            Button4.Image = My.Resources.influxdb_mini_grey
            Label2.Text = "InfluxDB OFF"
        Else
            ' Process is not running---get---RUN
            Shell("influxdb\influxd.exe", AppWinStyle.MinimizedFocus)
            Button4.Image = My.Resources.influxdb_mini
            Label2.Text = "InfluxDB Running"
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Node-RED control-------------------------------------
        p = Process.GetProcessesByName("node")
        If p.Count > 0 Then
            ' Process is running-------get---STOP
            Shell("taskkill.exe /f /t /im node.exe")
            Button2.Image = My.Resources.node_red_mini_grey
            Label3.Text = "Node-RED OFF"
        Else
            ' Process is not running---get---RUN
            Shell("node node-red\node_modules\node-red\red.js", AppWinStyle.MinimizedFocus)
            Button2.Image = My.Resources.node_red_mini
            Label3.Text = "Node-RED Running"
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        
        'Grafana control-------------------------------------
        p = Process.GetProcessesByName("grafana-server")
        If p.Count > 0 Then
            ' Process is running-------get---STOP
            Shell("taskkill.exe /f /t /im grafana-server.exe")
            Button3.Image = My.Resources.grafana_mini_grey
            Label4.Text = "Grafana OFF"
        Else
            'Process is not running---get---RUN 
            '_________________________________________________________Executar expecial para Grafana
            If Directory.GetCurrentDirectory.Contains("grafana\bin") Then
                GoTo go
            Else
                Directory.SetCurrentDirectory("grafana\bin")
                Console.WriteLine("Current directory: {0}", Directory.GetCurrentDirectory())
            End If
            '_________________________________________________________Agora vai executar a aplicação dentro "grafana\bin\"
go:
            Shell("grafana-server.exe", AppWinStyle.MinimizedFocus)
            Button3.Image = My.Resources.grafana_mini
            Label4.Text = "Grafana Running"
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Shell("taskkill.exe /f /t /im influxd.exe")
        Shell("taskkill.exe /f /t /im node.exe")
        Shell("taskkill.exe /f /t /im grafana-server.exe")
        Shell("taskkill.exe /f /t /im mosquitto.exe")
        Application.Exit()
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        Shell("taskkill.exe /f /t /im influxd.exe")
        Shell("taskkill.exe /f /t /im node.exe")
        Shell("taskkill.exe /f /t /im grafana-server.exe")
        Shell("taskkill.exe /f /t /im mosquitto.exe")


        Button4.Image = My.Resources.influxdb_mini_grey
        Label2.Text = "InfluxDB OFF"

        Button3.Image = My.Resources.grafana_mini_grey
        Label4.Text = "Grafana OFF"

        Button2.Image = My.Resources.node_red_mini_grey
        Label3.Text = "Node-RED OFF"

        Button1.Image = My.Resources.mosquitto_mini_grey
        Label1.Text = "Mosquitto OFF"



    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click

        If Not Directory.Exists("toolbox") Then
            Directory.CreateDirectory("toolbox")
        End If

        Process.Start("explorer.exe", "toolbox")
    End Sub
End Class
