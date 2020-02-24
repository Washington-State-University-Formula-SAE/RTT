import os
import can


# CAN
os.system('sudo ip link set can0 type can bitrate 500000')
os.system('sudo ifconfig can0 up')
can0 = can.interface.Bus(channel = 'can0', bustype = 'socketcan_ctypes')

# IOT
# sas = "SharedAccessSignature sr=hackathon2020fsae.azure-devices.net&sig=u7v565eWC1MMstYzDcl5kCXepcluJh8zcFko7SKTieg%3D&skn=iothubowner&se=1582764444"
# iot_hub_name = "hackathon2020fsae"
# device_id = "EngineRPM"
# device = MQTTDevice.MQTTDevice(sas,iot_hub_name, device_id )

# Receive messages
while True:
    msg = can0.recv(30.0)
    if msg:
        msg.split()
        print (msg)     
    else:
        print('No message was received')
    
       
os.system('sudo ifconfig can0 down')
