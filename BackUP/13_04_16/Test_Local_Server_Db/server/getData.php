<?php
$host = "localhost";
    $username = "root";
    $password = "root";
    $dbname = "radio";
	$con = mysqli_connect($host, $username, $password, $dbname) or die('Error in Connecting: ' . mysqli_error($con));
	$sql = "select * from serverlocation";
	$result = mysqli_query($con, $sql) or die("Error in Selecting " . mysqli_error($con));
	$emparray = array();
    while($row =mysqli_fetch_assoc($result))
    {
        $emparray[] = $row;
    }
    echo json_encode($emparray);

    //close the db connection
    mysqli_close($con);


?>