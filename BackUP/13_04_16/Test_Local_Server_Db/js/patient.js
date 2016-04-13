function profile()
{ 
	var pname = document.getElementById('pname').value;
	var pphone = document.getElementById('pMobile').value;
	var pemail = document.getElementById('pEmail').value;
	var pBirthDate = document.getElementById('pBirthDate').value;
	var pGender = document.getElementById("pGender").value;
	var pEducation = document.getElementById('pEducation').value;
	var pProfession = document.getElementById('pProfession').value;	
	var visitorId = localStorage.getItem("visitorId");
	var request = createCORSRequest( "post", "http://exhibition.tekticks.co.in" );
	//var fileName = upload();
	//alert(fileName);
	if(request)
	{
	
	
		var data = {"profile":[{"visitorId":visitorId,"pname":pname,"pemail":pemail,"pphone":pphone,"pGender":pGender,"pBirthDate":pBirthDate,"pEducation":pEducation,"pProfession":pProfession}]};
		var sendData = function(data)
		{
	$.ajax({
		url:"http://exhibition.tekticks.co.in/application/json/signupProfile_json.php",
		type: 'POST',
		contentType: 'application/json',
		data: JSON.stringify(data),
		dataType:"json",
		success:function(response)
		{
					if(JSON.stringify(response.status)==200)
						{
							myApp.alert('Data Updated','Update');
							var a = document.getElementById('reloadProfile');
							a.setAttribute("href","logo.html");
							document.getElementById('reloadProfile').click();
						}
							
		
		}
	  
		});
		} 
	sendData(data);
	//console.log(data);

	
	}
}