function signin()
{
	var request = createCORSRequest( "post", "http://radio.tekticks.co.in" );
	if(request)
	{
		var mobileNo = document.getElementById('mobileNo').value;
		var mobileNoValidate = validatePhone(mobileNo);
		if(mobileNoValidate)
		{
			$("#mobileError").hide();
		}
		else
		{
			$("#mobileError").fadeIn();
		}
		
		if(mobileNoValidate)
		{
		var data = {"otp":[{"mobileNo":mobileNo}]};
			var sendData = function(data)
			{   
				$.ajax
				({
				url: 'http://radio.tekticks.co.in/radioJson/create_otp_json.php',
				type: 'POST',
				contentType: 'application/json',
				data: JSON.stringify(data),
				dataType: 'json',
				success: function(response)
					{
						if(JSON.stringify(response.status)==200)
						{
							
							$("#loginInfo").text("Valid Credentials");
							$("#loginInfo").fadeIn();
							$("#mobileError").fadeOut();
							
							
							var otp = JSON.stringify(response.otp).replace(/"/g,"");
							
							localStorage.setItem("mobileNo", mobileNo);
							localStorage.setItem("otp", otp);
							
							//redirecting to otp.html
							var a = document.getElementById('signInNext');
							a.setAttribute("href","otp.html");
							document.getElementById('signInNext').click();
							
							myApp.alert('Your OTP Is '+otp,'OTP');
							
						}
						else if(JSON.stringify(response.status)==201)
						{
							$("#loginInfo").text(JSON.stringify(response.statusMessage).replace(/"/g,""));
							$("#loginInfo").fadeIn();
						}
			
					},
					error: function(xhr, textStatus, error)
					{
						console.log(xhr.statusText);
						console.log(textStatus);
						console.log(error);
					}
				});
			};
			sendData(data);
		}
	}
}
	
function verifyotp()
{
	var otp = document.getElementById('otp').value;
	var mobile=localStorage.getItem("mobileNo");
	var request = createCORSRequest( "post", "http://radio.tekticks.co.in" );
	if(request)
	{
		if(localStorage.getItem("otp")==otp)
		{
		var data = {"login":[{"mobileNo":mobile}]};
			var sendData = function(data)
			{   
				$.ajax
				({
				url: 'http://radio.tekticks.co.in/radioJson/login_details.php',
				type: 'POST',
				contentType: 'application/json',
				data: JSON.stringify(data),
				dataType: 'json',
				success: function(response)
					{
						if(JSON.stringify(response.status)==200)
						{

							myApp.alert(JSON.stringify(response.login).replace(/"/g,""),'Login');
							
							
							//redirecting to otp.html
							var a = document.getElementById('otpNex');
							a.setAttribute("href","title.html");
							document.getElementById('otpNex').click();

							
						}
			
					},
					error: function(xhr, textStatus, error)
					{
						console.log(xhr.statusText);
						console.log(textStatus);
						console.log(error);
					}
				});
			};
			sendData(data);
		}
		else
			{
				$("#otpError").text("Please enter a valid OTP");
				$("#otpError").fadeIn();
			}
	}
}
	

function accept()
{
	var flag='1';
	
	var request = createCORSRequest( "post", "http://radio.tekticks.co.in" );
	if(request)
	{
		if(flag!="")
		{
		var data = {"transaction":[{"flag":flag}]};
			var sendData = function(data)
			{   
				$.ajax
				({
				url: 'http://radio.tekticks.co.in/radioJson/accept_reject_json.php',
				type: 'POST',
				contentType: 'application/json',
				data: JSON.stringify(data),
				dataType: 'json',
				success: function(response)
					{
						if(JSON.stringify(response.status)==200)
						{
							
							myApp.alert('Accpeted','Patient Details');
							
							//redirecting to login.html
							var a = document.getElementById('acceptNext');
							a.setAttribute("href","login.html");
							document.getElementById('acceptNext').click();
							
						}

					},
					error: function(xhr, textStatus, error)
					{
						console.log(xhr.statusText);
						console.log(textStatus);
						console.log(error);
					}
				});
			};
			sendData(data);
		}
	}
}


function reject()
{
	var flag='0';
	
	var request = createCORSRequest( "post", "http://radio.tekticks.co.in" );
	if(request)
	{
		if(flag!="")
		{
		var data = {"transaction":[{"flag":flag}]};
			var sendData = function(data)
			{   
				$.ajax
				({
				url: 'http://radio.tekticks.co.in/radioJson/accept_reject_json.php',
				type: 'POST',
				contentType: 'application/json',
				data: JSON.stringify(data),
				dataType: 'json',
				success: function(response)
					{
						if(JSON.stringify(response.status)==200)
						{
							
							myApp.alert('Rejected','Patient Details');
							//redirecting to login.html
							var a = document.getElementById('rejectNext');
							a.setAttribute("href","login.html");
							document.getElementById('rejectNext').click();
							
						}
					},
					error: function(xhr, textStatus, error)
					{
						console.log(xhr.statusText);
						console.log(textStatus);
						console.log(error);
					}
				});
			};
			sendData(data);
		}
	}
}




	