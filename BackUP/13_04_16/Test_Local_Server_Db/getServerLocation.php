<?php
	include 'config.php';
    // read json file
    $filename = 'http://radio.tekticks.co.in/radioJson/serverLocation.php';
    $json = file_get_contents($filename);   
    //convert json object to php associative array
    $data = json_decode($json, true);
    // loop through the array
    foreach ($data as $row) 
	{
        // get the employee details
        $locationId = $row['locationId'];
        $deviceId = $row['deviceId'];
        $latitude = $row['latitude'];
		$longitude = $row['longitude'];
        $createdOn = $row['createdOn']; 
		$selectLocId=mysql_query("select locationId from serverlocation where locationId='$locationId'");
		$CountCheck=mysql_num_rows($selectLocId);
		if($CountCheck > 0)
		{
			
		}
		else
		{
			$insertData=mysql_query("INSERT INTO serverlocation(locationId, deviceId, latitude, longitude, createdOn) VALUES ('$locationId','$deviceId','$latitude','$longitude','$createdOn')");
		}
    }  
?>