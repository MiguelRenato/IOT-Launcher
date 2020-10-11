@echo off
echo. 
powershell write-host -back Red  _____This script was tested only on Windows 10!_____
powershell write-host -back DarkYellow _____________________Wait!__________________________
timeout 2 >nul
echo.
if not exist "C:\Program Files\nodejs\node.exe" (
powershell write-host -back DarkCyan OK nodejs not exist. Please install to run Node-RED!

wget.exe wget https://nodejs.org/dist/v14.13.0/node-v14.13.0-x64.msi
node-v14.13.0-x64.msi
del node-v14.13.0-x64.msi 
) else (
powershell write-host -back DarkCyan __OK nodejs exist now is cool to install Node-RED!__
)
echo.
pause
::---------------------------------------------------------------------------------------------
powershell write-host -back DarkCyan  [ Getting Mosquitto Container ]
wget.exe wget https://mosquitto.org/files/binary/win64/mosquitto-1.6.12-install-windows-x64.exe
7z.exe x mosquitto-1.6.12-install-windows-x64.exe -omosquitto -r
del mosquitto-1.6.12-install-windows-x64.exe
rmdir mosquitto\$PLUGINSDIR /s /q
del .wget-hsts
::---------------------------------------------------------------------------------------------
powershell write-host -back DarkCyan  [ Getting InfluxDB Container ]
wget.exe wget https://dl.influxdata.com/influxdb/releases/influxdb-1.8.3_windows_amd64.zip
7z.exe x influxdb-1.8.3_windows_amd64.zip
rename influxdb-1.8.3-1 influxdb
del influxdb-1.8.3_windows_amd64.zip
::---------------------------------------------------------------------------------------------
powershell write-host -back DarkCyan  [ Getting Grafana Container ]
timeout 2 >nul
wget.exe wget https://dl.grafana.com/oss/release/grafana-7.2.0.windows-amd64.zip
7z.exe x grafana-7.2.0.windows-amd64.zip
rename grafana-7.2.0 grafana
del grafana-7.2.0.windows-amd64.zip
::---------------------------------------------------------------------------------------------
powershell write-host -back DarkCyan   [ Getting Node-RED Container ]
npm install -g --unsafe-perm node-red --prefix ./node.red
