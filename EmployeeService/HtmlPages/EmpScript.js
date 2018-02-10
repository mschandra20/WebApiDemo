 
//<script type="text/javascript">
//AddEmp script
        $(document).ready(function () {

            if (localStorage.getItem('accessToken') === null) {
                window.location.href = "Login.html";
            }
            $("#txtFirstName, #txtLastName, #txtSalary, #txtGender").val('');
            
            $('#linkClose').click(function () {
                $('#divError').hide('fade');
            });
            $('#txtUsername').click(function () {
                $('#divError').hide('fade');

            });

            
               $('#btnSubmit').click(function () {
                   
                   var empObj = {
                            firstName: $('#txtFirstName').val(),
                            lastName: $('#txtLastName').val(),
                            salary: $('#txtSalary').val(),
                            gender: $('#txtGender').val()
                   };
               // $('#formAddEmp').submit(function (event) {
                    event.preventDefault(); // Prevent the form from submitting via the browser
                    //var form = $(this);
                $.ajax({
                    url: '/api/employees',
                    method: 'POST',
                    contentType: 'application/json',
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem('accessToken')
                    },

                    data: JSON.stringify(empObj),

                    /*$('#formAddEmp').serialize(),*/
                    success: function () {
                        //  $('#divErrorText').text(JSON.stringify(response));
                        $('#successModal').modal('show');

                        //$('#tblBody').append('<tr><td>' + newVal.ID + '</td><td>'
                        //    + newVal.FirstName + '</td><td>'
                        //    + newVal.LastName + '</td><td>'
                        //    + newVal.Gender + '</td><td>'
                        //    + newVal.Salary + '</td></tr>');
                        //window.location.href = 'Data.html';

                    },
                    error: function (jqXHR) {
                        $('#divErrorText').text(jqXHR.statusText + "   " + jqXHR.responseText);
                        $('#divError').show('fade');
                    }
                });
            });//End btnRegister click

            $('#btnLogOff').click(function () {
                localStorage.removeItem('accessToken');
                window.location.href = 'Login.html';
            });
       // });//end ready()


//Datascript
      //  $(document).ready(function () {     //Here we are telling to do this anonymous function when the DOM is ready


            if (localStorage.getItem('accessToken') === null) {
                window.location.href = "Login.html";
            }
            var uname = localStorage.getItem('userName');
            var name = String.empty;
            name = uname.split("@", 1);
            
               $('#spanUserName').text('Hello ' + name +' !'  );
        //    document.getElementById("spanUserName").innerHTML = uname;

            $('#errorModal').on('hidden.bs.modal', function () {
                 window.location.href = "Login.html";
             });

            //Get all employees button
            $('#btnGetAllEmployees').click(function () {  //Here we define click event with this id to perform
                //this anonymous function when a click happens

                

               // $('#tblData').show('fade');

                $.ajax({                    //Here we are making the AJAX request and it needs some parameters
                    type: 'GET',
                    url: "http://localhost:64753/api/employees",
                    dataType: 'json',
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem('accessToken')
                    },
                    success: function (data) { //On succesful execution of ajax we call this anonymous function

                        $('#tblData').removeClass('hidden').show('fade');
                      $('#tblBody').empty();

                       $.each(data, function (index, val) { // here we can define a function or can call any other function
                            //@param collection The object or array to iterate over. here it is DATA
                            //* @param callback The function that will be executed on every object.Will break the loop by returning false.
                            //* @returns the first argument, the object that is iterated.

                           $('#tblBody').append('<tr><td>' + val.ID + '</td><td>'
                                                           + val.FirstName + '</td><td>'
                                                           + val.LastName + '</td><td>'
                                                           + val.Gender + '</td><td>'
                                                           + val.Salary + '</td></tr>');
                                                  

                        });//End of $.each

                    },//End of Ajax Success function

                    complete: function (jqXHR) {
                        if (jqXHR.status === '401') {
                            empList.empty();
                            empList.append('<li style="color:red">'
                                + jqXHR.status + ':' + jqXHR.statusText + '</li>');

                        }
                    }

                });//End of Ajax request

            });//End of #btnGetAllEmployees click function

            $('#btnLogOff').click(function () {
                localStorage.removeItem('accessToken');
                window.location.href = 'Login.html';
            });
           
           

            //var clicks = 1;
            //$('#btnCount').click(function () { clicks++; $('#count').html(clicks); });

      //  });//End of doc ready

    //Login script
    //     $(document).ready(function () {
             $('#txtUsername').val('');

             $('#linkClose').click(function () {
                 $('#divError').hide('fade');
             });
             $('#txtUsername').click(function () {
                 $('#divError').hide('fade');
               
             });

            

             $('#btnLogin').click(function () {
                 $.ajax({
                     url: '/token',
                     method: 'POST',
                     contentType: 'application/json',
                     data: {
                         username: $('#txtUsername').val(),
                         Password: $('#txtPassword').val(),
                         grant_type: 'password'
                     },
                     success: function (response) {
                       //  $('#divErrorText').text(JSON.stringify(response));
                         localStorage.setItem('accessToken', response.access_token);
                         localStorage.setItem('userName', response.userName);
                         window.location.href = 'Data.html';
                        
                     },
                     error: function (jqXHR) {
                         $('#divErrorText').text(jqXHR.statusText + "   " + jqXHR.responseText);
                         $('#divError').show('fade');
                     }
                 });
             });//End btnRegister click
      //   });//end ready()

//Register script
    //    $(document).ready(function () {
            $('#txtEmail').val('');

            $('#linkClose').click(function () {
                $('#divError').hide('fade');
            });

            $('#txtEmail').click(function () {
                $('#divError').hide('fade');
                
            });

            $('#btnRegister').click(function () {

                $.ajax({
                    url:'/api/account/register',
                    method: 'POST',
                    data: {
                        email: $('#txtEmail').val(),
                        Password: $('#txtPassword').val(),
                        ConfirmPassword: $('#txtConfirmPassword').val(),
                    },
                    success: function () {
                        $('#successModal').modal('show');
                    },
                    error: function (jqXHR) {
                        $('#divErrorText').text(jqXHR.statusText +"   "+ jqXHR.responseText);
                        $('#divError').show('fade');
                    }
                });

            });//End btnRegister click 
            
        });//end ready()

