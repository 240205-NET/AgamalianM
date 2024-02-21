## HTTP Request

(HTTP Verb) (URI) (HTTP Version)

GET http://jsonplaceholder.typicode.com/posts/2 HTTP/1.1
(Parameter) : (Value)
Host: http://jsonplaceholder.typicode.com
Accept: image/gif, image/jpeg
Accept-Language: en-us
User-Agent: Mozilla/4.0
Content-Length: 29

(blank line denotes the end of the headers)

bookId=123&author=Tan+Ah+Teck



POST https://localhost:7266/sample HTP/1.1
accept: */*
Content-Type: aplication/json

18





## HTTP Response

(HTTP Version) (HTTP Status Code) (Status code text)

HTTP/1.1 200 OK
(possible headers
some headers are for requests only,
some headers are for responses only,
and some are for both to describe the body when there is one)

(blank line to separate the body again)
{body response}

GET- retrieve a resource
HEAD- only retrieves the header of a similar GET request
POST- create an entry (at a specified location)
PUT- replace the entry with the request payload
PATCH- update the entry
DELETE- delete the specified resource
OPTIONS- requests the available mathods that the endpoint can handle

SAFE methods - actions (verbs) that do not alter the state of the server

Idempotent - an identical request can be made several time in a row with the same effect and leave the server in the same state as after the tirst request.

*ALL Safe methods are Idempotent
