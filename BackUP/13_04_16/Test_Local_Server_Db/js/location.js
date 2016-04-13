
//var pictureSource; // picture source
//var destinationType; // sets the format of returned value
// Wait for device API libraries to load
//
document.addEventListener("deviceready", onDeviceReady, false);


function onDeviceReady() {
	
	/*var lati=localStorage.getItem("latitude");
	var longi=localStorage.getItem("longitude");
	var uid=localStorage.getItem("uuid");
	alert("locationsend called");
	var request = createCORSRequest( "post", "http://radio.tekticks.co.in" );
	if(request)
	{
	var data = {"location":[{"uuid":uuid,"latitude":lat,"longitude":lon}]};
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
			
				alert("success");
			
			}
		}
	});
	}
sendData(data);	
	*/
	
	
	
	//alert("ondeviceready called");
	/*alert("hiii");
	var c=function(pos)
	{
		//finding coordinates
		var lat		=pos.coords.latitude;
		var lon		=pos.coords.longitude;
		var coords	=lat+', '+lon;
		//finding universally unique identifier(uuid)	
		var uuid=device.uuid;
		
		alert(coords);
		alert(uuid);
		
		localStorage.setItem("latitude",lat);
		localStorage.setItem("longitude",lon);
		localStorage.setItem("uuid",uuid);
		alert("done");
	}
	navigator.geolocation.getCurrentPosition(c);*/
	
	
	
	
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
						alert("success");
						/*if(JSON.stringify(response.status)==200)
						{
							alert(JSON.stringify(response.visitor.locationId).replace(/"/g,""));
						}
						else if(JSON.stringify(response.status)==201)
						{
							alert(response.statusMessage);
						}*/
			/*
					}
					
				});
			}
		sendData(data);*/
//}

}
 