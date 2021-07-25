<?php  
$username   =   $_GET["user"]; 
$password   =   $_GET["pass"]; 
include("config.php");
   session_start();
      $myusername = mysqli_real_escape_string($db,$username);
      $mypassword = mysqli_real_escape_string($db,$password); 
      
      $sql = "SELECT * FROM clients WHERE username = '$myusername' and password = '$mypassword'";
      $result = mysqli_query($db,$sql);
      $row = mysqli_fetch_array($result,MYSQLI_ASSOC);
      
      $count = mysqli_num_rows($result);
      // If result matched $myusername and $mypassword, table row must be 1 row
		
      if($count == 1) {
         // success
		 //print session 
		     echo $row['session_id'];
      }else {
		  //fail 
		  echo "fail" ;  
      }


?>  