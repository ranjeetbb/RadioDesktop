function receive()
{						
		$.ajax({
		url:"http://localhost/Test_Local_Server_Db/send_local_data.php",
		type: 'POST',
		contentType: 'application/json',		
		dataType:"json",
		success:function(response)
		{	
			var n=Object.keys(response.doctor_mobile).length;
			var tolArray=[];
			$.each(response.doctor_mobile);
			//alert(n);	//array for device id
			var Ra_dr_Id = []; // create array here
			$.each(response.doctor_mobile, function (index, doctor_mobile) {
			Ra_dr_Id.push(doctor_mobile.Ra_dr_Id); //push values here
			});
			
			//alert(Ra_dr_Id);
			
			//alert(n);	//array for device id
			var radio_mob = []; // create array here
			$.each(response.doctor_mobile, function (index, doctor_mobile) {
			radio_mob.push(doctor_mobile.Ra_M); //push values here
			});
			
			//alert(radio_mob);	
			//alert(n);	//array for device id
			var Altr_M = []; // create array here
			$.each(response.doctor_mobile, function (index, doctor_mobile) {
			Altr_M.push(doctor_mobile.Altr_M); //push values here
			});
			
			//alert(Altr_M);	

			//alert(n);	//array for device id
			var Altr_M1 = []; // create array here
			$.each(response.doctor_mobile, function (index, doctor_mobile) {
			Altr_M1.push(doctor_mobile.Altr_M1); //push values here
			});
			
			//alert(Altr_M1);	
			
			$.ajax({
					  url:"http://radio.tekticks.co.in/radioJson/api.php",
					  //url:"api.php",
                      type:"post",                   
                      data:{type:Ra_dr_Id},
                      cache: false,
                      success: function(response){
                          //alert("Ok");
                      },
                      error: function(err){
                          //alert("Error");
                      }
                  })	

			 $.ajax({
					  url:"http://radio.tekticks.co.in/radioJson/api.php",
					  //url:"api.php",
                      type:"post",                   
                      data:{type1:radio_mob},
                      cache: false,
                      success: function(response){
                          //alert("Ok");
                      },
                      error: function(err){
                          //alert("Error");
                      }
                  })

			 $.ajax({
					  url:"http://radio.tekticks.co.in/radioJson/api.php",
					  //url:"api.php",
                      type:"post",                   
                      data:{type2:Altr_M},
                      cache: false,
                      success: function(response){
                          //alert("Ok");
                      },
                      error: function(err){
                          //alert("Error");
                      }
                  })	

			   $.ajax({
					  url:"http://radio.tekticks.co.in/radioJson/api.php",
					  //url:"api.php",
                      type:"post",                   
                      data:{type3:Altr_M1},
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
			


	







	