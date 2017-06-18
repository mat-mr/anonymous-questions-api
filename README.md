# anonymous-questions-api

#### Get all questions
    [GET] /api/questions

#### Get question by id 
    [GET] /api/questions/{id}

#### Post question - JSON Structure { Title: 'title', Body: 'message body' }
    [POST] /api/questions
    
#### Post reply to question 
    [POST] /api/questions/{idQuestion}/reply
    
#### Get replies of a question 
    [GET] /api/questions/{idQuestion}/replies    
  
#### Delete question by id 
    [DELETE] /api/questions/{id}
