# Notes for managing the project

Publish mqtt message:

`mosquitto_pub -h localhost -p 1883 -t 'publisher1/messages/test' -m 'hello mqtt' `

Subscribe for a publisher:

`mosquitto_sub -v -h localhost -p 1883 -t "publisher1/messages/#"`

Get opc publisher configs for PLCs form the from the following urls:

- http://localhost:8081/pn.json
- http://localhost:8082/pn.json
- http://localhost:8083/pn.json
