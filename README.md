# childrens_book_list
An ASP.NET Core REST API to provide and maintain a list of recommended children's books to foster the 
intellectual growth and development of children ages 5 to 14.

Each Book resource includes the following information:

    Title
    Author
    Illustrator
    Year Published
    Number of Pages
    Reading Age
    Grade Level
    
API services are accessible to the client by mapping a combination of a specific URI segment along with its 
corresponding HTTP Request code, as shown in the table below. Resources (book information) are delivered 
via JSON payloads back to the consumer.

This API offers standard CRUD operations (Create, Read, Update, Delete) to a front-end consumer application.

*************************************************************************************************************
API End Points for "ChildrensBookList"					
*************************************************************************************************************
					
URI			HTTP Verb	Operation	Description	                     Success	     Failure

/api/books	        GET	        READ	    Read all resources	             200 OK	         400 Bad Request
                                                                                             404 Not Found
                                                                                             
/api/books/{id}	    GET	        READ	    Read a single resource	         200 OK	         400 Bad Request
                                                                                             404 Not Found
                                                                                             
/api/books	        POST	    CREATE	    Create a new resource	         201 Created	 400 Bad Request
                                                                                             405 Not Allowed
                                                                                             
/api/books/{id}	    PUT	        UPDATE	    Update an entire resource	     204 No Content  400 Bad Request
                                                                                             405 Not Allowed
                                                                                             
/api/books/{id}	    PATCH	    UPDATE	    Update a resource partially	     204 No Content	 400 Bad Request
                                                                                             405 Not Allowed
                                                                                              
/api/books/{id}	    DELETE	    DELETE	    Delete a single resource	     200 OK          400 Bad Request
                                                                             204 No Content	 405 Not Allowed
                                                                             
*************************************************************************************************************
                                                                             

This API may serve as a useful tool for teachers and educators to maintain and share a recommended book list
between classes and schools, as well as offer suggestions for parents and students.

API created and maintained by Darron Vanaria
dvanaria@gmail.com


