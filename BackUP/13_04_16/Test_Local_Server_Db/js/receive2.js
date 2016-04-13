function receive2()
{	
	var request = createCORSRequest( "post","http://radio.tekticks.co.in" );
	if(request)					
		$.ajax({
		url:"http://radio.tekticks.co.in/radioJson/test_doctr.php",
		type: 'POST',
		contentType: 'application/json',		
		dataType:"json",
		success:function(response)
		{	
			var n=Object.keys(response.doctors).length;
			//alert(n);	//array for device id
			var dctrID = []; // create array here
			$.each(response.doctors, function (index, doctors) {
			dctrID.push(doctors.dctrID); //push values here
			});
			
			/* var dctrM = []; //array for latitude id
			$.each(response.doctors, function (index, doctors) {
			dctrM.push(doctors.dctrM); //push values here
			});
			
			var Alter1 = []; //array for Longi id
			$.each(response.doctors, function (index, doctors) {
			Alter1.push(doctors.Alter1); //push values here
			});
			
			var Alter2 = []; //array for CreatedOn id
			$.each(response.doctors, function (index, doctors) {
			Alter2.push(doctors.Alter2); //push values here
			}); */
			
			var flag = []; //array for CreatedOn id
			$.each(response.doctors, function (index, doctors) {
			flag.push(doctors.flag); //push values here
			});
			
			var stDate = []; //array for CreatedOn id
			$.each(response.doctors, function (index, doctors) {
			stDate.push(doctors.stDate); //push values here
			});
			//alert(dctrMID);
			//alert(dctrID);
			//alert(dctrM);
			//alert(flag);
			
			//array for device id
			//var jsonString=JSON.stringify(deviceId);
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {dc_data : dctrID}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});
					
			//array for latitude id
			//var jsonString1=JSON.stringify(latitude);
			/* $.ajax({
			type: "POST",
			url: "getelement.php",
			data: {dc_data1 : dctrM}, 
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
			data: {dc_data2 : Alter1}, 
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
			data: {dc_data3 : Alter2}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});	 */

			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {dr_flag : flag}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});	
					
					$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {dr_date : stDate}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});
		}
		});
}
			


	







	