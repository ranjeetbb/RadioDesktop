function receive1()
{	
	var request = createCORSRequest( "post","http://radio.tekticks.co.in" );
	if(request)					
		$.ajax({
		url:"http://radio.tekticks.co.in/radioJson/test_tans.php",
		type: 'POST',
		contentType: 'application/json',		
		dataType:"json",
		success:function(response)
		{	
			var n=Object.keys(response.transaction).length;
			//alert(n);	//array for device id
			var T_Id = []; // create array here
			$.each(response.transaction, function (index, transaction) {
			T_Id.push(transaction.T_Id); //push values here
			});
			
			var trans_id = []; // create array here
			$.each(response.transaction, function (index, transaction) {
			trans_id.push(transaction.tansID); //push values here
			});
			
			var trans_flag = []; //array for latitude id
			$.each(response.transaction, function (index, transaction) {
			trans_flag.push(transaction.flag); //push values here
			});
			
			var trans_creat = []; //array for Longi id
			$.each(response.transaction, function (index, transaction) {
			trans_creat.push(transaction.creDate); //push values here
			});
		
			//alert(trans_id);
			//alert(trans_flag);
			//alert(trans_creat);
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {trs_Id : T_Id}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});
			
			//array for device id
			//var jsonString=JSON.stringify(deviceId);
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {trans_data : trans_id}, 
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
			data: {trans_data1 : trans_flag}, 
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
			data: {trans_data2 : trans_creat}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					}); 									
		}
		});
}
			


	







	