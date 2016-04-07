<?php
header('Access-Control-Allow-Origin: *');
include 'config.php';

$cars = array();
$cars =@$_POST['type'];
$arrlength = count($cars);
for($x =0; $x <$arrlength; $x++)
{  
	$devID=$cars[$x];	
	/* $query=mysql_query("insert into servertransactions(transactionId,flag) values('$cars[$x]','1')");
	echo 'ok'; */
	/* $selectQuery="select * from servertransactions where transactionId=$devID";
	$resQuery=mysql_query($selectQuery,$conn);
	$num_rows = mysqli_num_rows($resQuery); */
	
	$updateQuery="UPDATE servertransactions SET flag=1 where transactionId=$devID";
	$updateRun=mysql_query($updateQuery,$conn);
	
}
?>