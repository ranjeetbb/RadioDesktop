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
			
			var trans_flag = []; //array for latitude id
			$.each(response.transaction, function (index, transaction) {
			trans_flag.push(transaction.flag); //push values here
			});
			
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {trs_Id : T_Id}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});
			$.ajax({
			type: "POST",
			url: "getelement.php",
			data: {trans_data1 : trans_flag}, 
			cache: false,
			success: function(){
            //alert("OK");
							}
					});														
		}
		});
}
			


	







	