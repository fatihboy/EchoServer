# Echo Server
A simple http server that response with given constant value or request body. 

## Usage
Echo Server application accepts following parameters;

### Do not reply request headers
In order to response without request headers use;

    --noHeader

### Constant Response
In order to return a contant response body use;

    --response=[RESPONSE_BODY]

i.e:

    --response=HelloWorld

