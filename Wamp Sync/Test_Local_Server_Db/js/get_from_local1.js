function receive1()
{						
		$.ajax({
		url:"http://localhost/Test_Local_Server_Db/send_local_data1.php",
		type: 'POST',
		contentType: 'application/json',		
		dataType:"json",
		success:function(response)
		{	
			var n=Object.keys(response.transaction).length;
			//alert(n);	//array for device id
			var transID = []; // create array here
			$.each(response.transaction, function (index, transaction) {
			transID.push(transaction.transID); //push values here
			});
					
			$.ajax({
					  url:"http://radio.tekticks.co.in/radioJson/api.php",
					  //url:"api.php",
                      type:"post",                   
                      data:{type4:transID},
                      cache: false,
                      success: function(response){
                          //alert("Ok");
                      },
                      error: function(err){
                          //alert("Error");
                      }
                  })			 
		}
		});
}