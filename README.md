# SampleCode
Some sample code to parse a string

Converts the string: 
"(id,created,employee(id,firstname,employeeType(id),lastname),location)" 

To the following output:
id<br/>
created<br/>
employee<br/>
– id<br/>
– firstname<br/>
– employeeType<br/>
–– id<br/>
– lastname<br/>
location<br/>

And (output in alphabetical order):
created<br/>
employee<br/>
– employeeType<br/>
–– id<br/>
– firstname<br/>
– id<br/>
– lastname<br/>
id<br/>
location<br/>
