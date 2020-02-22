from paho.mqtt import client as mqtt
import time
import ssl

def on_subscribe(client, userdata, mid, granted_qos):
    print('Subscribed for m' + str(mid))

def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))

def on_message(client, userdata, message):
    print("Received message '" + str(message.payload) + "' on topic '" + message.topic + "' with QoS " + str(message.qos))

def on_log(client, userdata, level, buf):
    print("log: ",buf)

class MQTTDevice:
    def __init__(self, sas_token, iot_hub_name, device_id):
        self.iot_hub_name = iot_hub_name
        self.sas_token = sas_token
        self.client = mqtt.Client(client_id=device_id, protocol=mqtt.MQTTv311,  clean_session=False)
        self.client.on_log = on_log
        self.client.tls_set_context(context=None)

        self.username = "{}.azure-devices.net/{}/api-version=2018-06-30".format(iot_hub_name, device_id)
        self.client.username_pw_set(username=self.username, password=sas_token)

        # Connect to the Azure IoT Hub
        self.client.on_connect = on_connect
        self.client.connect(iot_hub_name+".azure-devices.net", port=8883)

        # Publish 
        self.client.publish("devices/{device_id}/messages/events/".format(device_id=device_id), payload="{}", qos=0, retain=False)

        # Subscribing on the topic , 
        self.client.on_message = on_message
        self.client.on_subscribe = on_subscribe 
        self.client.subscribe("devices/{device_id}/messages/devicebound/#".format(device_id=device_id))
        self.client.subscribe("$iothub/twin/PATCH/properties/desired/#")
        self.client.subscribe("$iothub/methods/POST/#")

    def SendMessage(self, topic, payload):
        self.client.publish(topic, payload=payload, qos=0, retain=False)
    def LoopForever(self):
        self.client.loop_forever()

    ##device_id = "MyPythonDevice"
    ##iot_hub_name = "fsaehackathon2020"
    ##sas_token = "SharedAccessSignature sr=fsaehackathon2020.azure-devices.net%2Fdevices%2FMyPythonDevice&sig=9pmtcpFdf%2Fd5CpZrmRkeZz2rhc3kVerIgbxUl0QraXY%3D&se=1582758616"
    ##client = mqtt.Client(client_id=device_id, protocol=mqtt.MQTTv311,  clean_session=False)
    #client.on_log = on_log
    #client.tls_set_context(context=None)

    # Set up client credentials
    #username = "{}.azure-devices.net/{}/api-version=2018-06-30".format(iot_hub_name, device_id)
    #client.username_pw_set(username=username, password=sas_token)

    # Connect to the Azure IoT Hub
    #client.on_connect = on_connect
    #client.connect(iot_hub_name+".azure-devices.net", port=8883)

    # Publish 
    #client.publish("devices/{device_id}/messages/events/".format(device_id=device_id), payload="{}", qos=0, retain=False)

    # Subscribing on the topic , 
    #client.on_message = on_message
    #client.on_subscribe = on_subscribe 
    #client.subscribe("devices/{device_id}/messages/devicebound/#".format(device_id=device_id))
    #client.subscribe("$iothub/twin/PATCH/properties/desired/#")
    #client.subscribe("$iothub/methods/POST/#")

    #client.loop_forever()
