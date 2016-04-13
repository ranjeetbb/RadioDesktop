<html>
<head>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script>
 $.ajax({
					  url:"http://radio.tekticks.co.in/radioJson/inser_Dctr_Mobile.php",
					  //url:"api.php",
                      type:"post",                                     
                      cache: false,
                      success: function(response){
                          alert("Ok");
                      },
                      error: function(err){
                          alert("Error");
                      }
                  })
</script>
</head>
<body>
</body>
</html>