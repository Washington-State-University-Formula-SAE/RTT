from paho.mqtt import client as mqtt
import time
import ssl
import MQTTDevice

sas = "SharedAccessSignature sr=fsaehackathon2020.azure-devices.net%2Fdevices%2FMyPythonDevice&sig=9pmtcpFdf%2Fd5CpZrmRkeZz2rhc3kVerIgbxUl0QraXY%3D&se=1582758616"
iot_hub_name = "hackathon2020fsae"
device_id = "MyPythonDevice"
device = MQTTDevice.MQTTDevice(sas,iot_hub_name, device_id )
for i in range(10):
    device.SendMessage("topic", "helloWorld"+str(i))
