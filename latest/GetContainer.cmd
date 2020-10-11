@echo off
echo.
echo.
powershell write-host -back Red  [ This script was tested only on Windows 10. ]
timeout 4 >nul
if not exist "C:\Program Files\nodejs\node.exe" (
powershell write-host -back DarkCyan  [ Install node.js to run Node-RED ]
wget.exe wget https://nodejs.org/dist/v14.13.0/node-v14.13.0-x64.msi
node-v14.13.0-x64.msi
del node-v14.13.0-x64.msi 
) else (
echo.
powershell write-host -back DarkCyan [ OK nodejs exist do another thing! ]
)
timeout 4 >nul
echo.
::---------------------------------------------------------------------------------------------
powershell write-host -back DarkCyan  [ Getting Mosquitto Container]
wget.exe https://mosquitto.org/files/binary/win64/mosquitto-1.6.12-install-windows-x64.exe
7z.exe x mosquitto-1.6.12-install-windows-x64.exe -ocontainer/mosquitto -r
del mosquitto-1.6.12-install-windows-x64.exe
rmdir container\mosquitto\$PLUGINSDIR /s /q
del .wget-hsts
::---------------------------------------------------------------------------------------------
powershell write-host -back DarkCyan  [ Getting InfluxDB Container ]
wget.exe wget https://dl.influxdata.com/influxdb/releases/influxdb-1.8.3_windows_amd64.zip
7z.exe x influxdb-1.8.3_windows_amd64.zip
rename influxdb-1.8.3-1 influxdb
timeout 1 >nul
move influxdb container/influxdb
del influxdb-1.8.3_windows_amd64.zip
::---------------------------------------------------------------------------------------------
powershell write-host -back DarkCyan  [ Getting Grafana Container ]
wget.exe wget https://dl.grafana.com/oss/release/grafana-7.2.0.windows-amd64.zip
7z.exe x grafana-7.2.0.windows-amd64.zip
move grafana-7.2.0 container/grafana
timeout 1 >nul
del grafana-7.2.0.windows-amd64.zip
powershell write-host -back DarkCyan   [ Getting Node-RED Container ]
::---------------------------------------------------------------------------------------------
npm install -g --unsafe-perm node-red --prefix ./container/node-red
