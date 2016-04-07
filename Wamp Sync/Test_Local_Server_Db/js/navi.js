function navi()
{
	var request = createCORSRequest( "post", "http://radio.tekticks.co.in" );
	if(request)
	{
		
		var c=function(pos)
		{
		//finding coordinates
		var lat		=pos.coords.latitude;
		var lon		=pos.coords.longitude;
		var coords	=lat+', '+lon;
		//finding universally unique identifier(uuid)	
		var uuid=device.uuid;
		
		localStorage.setItem("latitude",lat);
		localStorage.setItem("longitude",lon);
		localStorage.setItem("uuid",uuid);
		locationSend();
		}
		navigator.geolocation.getCurrentPosition(c);
		
		/*var data = {"location":[{"uuid":uuid,"latitude":lat,"longitude":lon}]};
		alert(data);
		//console.log(data);
		var sendData = function(data)
			{   
				$.ajax
				({
				url: 'http://radio.tekticks.co.in/radioJson/location_new_json.php',
				type: 'POST',
				contentType: 'application/json',
				data: JSON.stringify(data),
				dataType: 'json',
				success: function(response)
					{
						//console.log(response);
						
						if(JSON.stringify(response.status)==200)
						{
							
							alert(JSON.stringify(response.visitor.locationId).replace(/"/g,""));
						}
						else if(JSON.stringify(response.status)==201)
						{
							alert(response.statusMessage);
						}
			
					}
					
				});
			}
		sendData(data);
		*/
		
		
		/*if(localStorage.getItem("visitorId") === null)
		{
			$("#signup").fadeIn();
			$("#signin").fadeIn();
			$("#profile").fadeOut();
			document.getElementById("list1").style.marginTop = "0px";			
		}
		else
		{
			$("#signup").fadeOut();
			$("#signin").fadeOut();
			$("#profile").fadeIn();	
		
		}*/
	}
	//profileReload();
}


function locationSend()
{
	var lat=localStorage.getItem("latitude");
	var lon=localStorage.getItem("longitude");
	var uuid=localStorage.getItem("uuid");
	
	var request = createCORSRequest( "post", "http://radio.tekticks.co.in" );
	if(request)
	{
	var data = {"location":[{"uuid":uuid,"latitude":lat,"longitude":lon}]};
	console.log(data);
	var sendData = function(data)
	{
	$.ajax({
		url:"http://radio.tekticks.co.in/radioJson/location_new_json.php",
		dataType:"json",
		type: 'POST',
		data: JSON.stringify(data),
		contentType: 'application/json',
		success:function(response)
		{	
		if(JSON.stringify(response.status)==200)
			{ 
			
				
			
			}
			if(JSON.stringify(response.status)==203)
			{ 
			
				
			
			}
		}
	});
	}
sendData(data);	
//console.log(data);
	}
}
