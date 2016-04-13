<?php
header("refresh:5 ");
?>
<?php
include('config.php');
?>
<html>
<head>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" src="js/cors.js"></script>
<script type="text/javascript" src="js/receive.js"></script>
<script type="text/javascript" src="js/receive1.js"></script>
<script type="text/javascript" src="js/receive2.js"></script>
</head>
<body onload="receive();receive1();receive2()">
<form method="post" >
  <!--<input type="button" name="button" value="button" >-->
  <h1>Please Do not close this window.. <img src="loading.gif"><h1>
</form>
</body>
</html>
<?php
//$devID=array();		//code for serverlocation
$ser_Id = array();
$ser_Id =@$_POST['servId'];
$Idlength = count($ser_Id);
//print_r($ser_Id);

$cars = array();
$cars =@$_POST['data'];
$arrlength = count($cars);
//print_r($cars);
	 
$cars1 = array();
$cars1 =@$_POST['data1'];
$arrlength1 = count($cars1);
//print_r($arrlength1);
	 
$cars2 = array();
$cars2 =@$_POST['data2'];
$arrlength2 = count($cars2);
//print_r($arrlength2);
	 
$cars3 = array();
$cars3 =@$_POST['data3'];
$arrlength3 = count($cars3);
for($x =0; $x <$Idlength; $x++) 
{  
	$devID=$ser_Id[$x];
	//echo "De".$cars[$x]."<br>";
	//echo "La".$cars1[$x]."<br>";
	$chk=mysql_query("select locationId from serverlocation where locationId='$devID'");
	$count=mysql_num_rows($chk);
	if($count > 0)
	{
		//echo $cars[$x];
	}
	else
	{
    echo $query=mysql_query("insert into serverlocation(locationId,deviceId,latitude,longitude,
	createdOn) values('$ser_Id[$x]','$cars[$x]','$cars1[$x]','$cars2[$x]','$cars3[$x]')");
	}
}
$devId=array();
$selDeId=mysql_query("select locationId from serverlocation");
while($row=mysql_fetch_array($selDeId))
{
	$devId[]=$row['locationId'];
}
 $tol=count($devId);
$y=0;
for($i=0; $i<$tol;$i++)
{
	for($a=0; $a <$arrlength; $a++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update serverlocation set deviceId='$cars[$a]' where locationId='$devId[$i]'");	
		if($i == $a)
			break;
	} 
	for($y=0; $y <$arrlength1; $y++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update serverlocation set latitude='$cars1[$y]' where locationId='$devId[$i]'");	
		if($i == $y)
			break;
	} 
	for($z=0; $z <$arrlength2; $z++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update serverlocation set longitude='$cars2[$z]' where locationId='$devId[$i]'");	
		if($i == $z)
			break;
	} 
	for($k=0; $k <$arrlength3; $k++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update serverlocation set createdOn='$cars3[$k]' where locationId='$devId[$i]'");	
		if($i == $k)
			break;
	} 
}
//$devID=array();
$cars7 = array();				//code for doctors
$cars7 =@$_POST['dc_data'];
$arrlength7 = count($cars7);
	 
/* $cars8 = array();
$cars8 =@$_POST['dc_data1'];
$arrlength8 = count($cars8);
//print_r($arrlength1);
	 
$cars9 = array();
$cars9 =@$_POST['dc_data2'];
$arrlength9 = count($cars9);
//print_r($arrlength2);
	 
$cars10 = array();
$cars10 =@$_POST['dc_data3'];
$arrlength10 = count($cars10); */

$status=array();
$status=@$_POST['dr_flag'];
$lenflag=count($status);

$stDate=array();
$stDate=@$_POST['dr_date'];
$lenDate=count($stDate);
	 
for($x =0; $x <$arrlength7; $x++) 
{  
	$devID=$cars7[$x];
	//echo "De".$cars[$x]."<br>";
	//echo "La".$cars1[$x]."<br>";
	$chk=mysql_query("select doctorId from doctormobilenumber where doctorId='$devID'");
	$count=mysql_num_rows($chk);
	if($count > 0)
	{
		//echo $cars[$x];
	}
	else
	{
	echo $query=mysql_query("insert into doctormobilenumber(doctorId,flag,statusDate) values('$cars7[$x]','$status[$x]','$stDate[$x]')");
	}
}
$devId=array();
$selDeId=mysql_query("select doctorId from doctormobilenumber");
while($row=mysql_fetch_array($selDeId))
{
	$devId[]=$row['doctorId'];
}
$tol=count($devId);
for($i=0; $i<$tol;$i++)
{
	/* for($y=0; $y <$arrlength8; $y++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update doctormobilenumber set mobileNumber='$cars8[$y]' where doctorId='$devId[$i]'");	
		if($i == $y)
			break;
	} 
	for($z=0; $z <$arrlength9; $z++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update doctormobilenumber set alternateMobile1='$cars9[$z]' where doctorId='$devId[$i]'");	
		if($i == $z)
			break;
	} 
	for($k=0; $k <$arrlength10; $k++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update doctormobilenumber set alternateMobile2='$cars10[$k]' where doctorId='$devId[$i]'");	
		if($i == $k)
			break;
	}  */
	for($L=0; $L <$lenflag; $L++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update doctormobilenumber set flag='$status[$L]' where doctorId='$devId[$i]'");	
		if($i == $L)
			break;
	} 
	for($M=0; $M <$lenDate; $M++) 
	{  
		//echo $devId[$i]." <br>" ;
		//echo $cars1[$y]." <br>" ;
		$query=mysql_query("update doctormobilenumber set statusDate='$stDate[$M]' where doctorId='$devId[$i]'");	
		if($i == $M)
			break;
	} 
}
 ?>
 <script>
 /* var cars= '<?php echo json_encode($devId) ;?>';
 //alert(cars);
  $.ajax({
			url:"http://radio.tekticks.co.in/radioJson/deleteDoctors.php",
					  //url:"api.php",
                      type:"post",                   
                      data:{doctorID:cars},
                      cache: false,
                      success: function(response){
                          //alert("Ok");
                      },
                      error: function(err){
                          //alert("Error");
                      }
                  }) */
 </script>