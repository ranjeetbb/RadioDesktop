<?php
header('Access-Control-Allow-Origin: *');
include 'config.php';

$cars = array();
$cars =@$_POST['type1'];
$arrlength = count($cars);
for($x =0; $x <$arrlength; $x++)
{  
	$devID=$cars[$x];	
	$updateQuery="UPDATE servertransactions SET flag=2 where transactionId=$devID";
	$res=mysql_query($updateQuery,$conn);
	
}
?>