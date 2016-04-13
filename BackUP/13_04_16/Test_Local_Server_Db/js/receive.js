function receive()
{	
	var request = createCORSRequest( "post","http://radio.tekticks.co.in" );
	if(request)					
		$.ajax({
		url:"http://radio.tekticks.co.in/radioJson/test.php",
		type: 'POST',
		contentType: 'application/json',		
		dataType:"json",
		success:function(response)
		{	
			var n=Object.keys(response.location).length;
			//alert(n);	//array for device id
			var tolArray=[];
			tolArray.push(response.location);
			//alert(tolArray);
			var serId = []; // create array here
			$.each(response.location, function (index, location) {
			serId.push(location.ser_Id); //push values here
			});
			
			var deviceId = []; // create array here
			$.each(response.location, function (index, location) {
			deviceId.push(location.DeID); //push values here
			});
			
			var latitude = []; //array for latitude id
			$.each(response.location, function (index, location) {
			latitude.push(location.Lati); //push values here
			});
			
			var LongiID = []; //array for Longi id
			$.each(response.location, function (index, location) {
			LongiID.push(location.Longi); //push values here
			});
			
			var CreatedOn = []; //array for CreatedOn id
			$.each(response.location, function (index, location) {
			CreatedOn.push(location.CreOn); //push values here
			});
			//alert(deviceId);
			//alert(latitude);
			//alert(LongiID);
			//alert(CreatedOn);
			
			//array for device id
			//var jsonString=JSON.stringify(deviceId);
			
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {servId : serId}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});
			
			
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {data : deviceId}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});
					
			//array for latitude id
			//var jsonString1=JSON.stringify(latitude);
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {data1 : latitude}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});
					
			//array for LongiID id
			//var jsonString2=JSON.stringify(LongiID);
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {data2 : LongiID}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});
					
			//array for CreatedOn id
			//var jsonString3=JSON.stringify(CreatedOn);
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {data3 : CreatedOn}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});

			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {objectArray : tolArray}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});	
		}
		});
}
			


	







	