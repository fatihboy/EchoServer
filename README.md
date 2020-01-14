# Echo Server
A simple http server that response with given constant value or request body. 

## Usage
Echo Server application checks following environment variables;

### Reply request headers
In order to response with request headers use;

    REPLY_HEADERS=true

### Constant Response
In order to return a contant response body use;

    RESPONSE_BODY=[RESPONSE_BODY]

i.e:

    RESPONSE_BODY=Hello World!

Docker image can be found at https://hub.docker.com/r/enterprisecodingcom/echo-server

Latest version can be pull with following command:

    docker push enterprisecodingcom/echo-server:latest

## Usage Samples
Application can be run with following command:

    docker run -d -p 8000:80 enterprisecodingcom/echo-server:latest

Use following command to reply request headers

    docker run -d -p 8000:80 enterprisecodingcom/echo-server:latest -e REPLY_HEADERS=true

or use following command to reply with custom message;

    docker run -d -p 8000:80 enterprisecodingcom/echo-server:latest -e RESPONSE_BODY="Hello World!"

### Test

Send a post request to localhost:8000 to test echo-server

     curl -X POST -i --data "Hello World" -H "created-by: Fatih Boy" http://localhost:8000


