<?php
include_once("db_config.php");
ini_set('max_execution_time', 300);

define('MESSAGE_0','Success');
define('MESSAGE_101','No users found.');
define('MESSAGE_501','An unknown error occurred!');
class ws_common
{			
	public function InsertTokenIntoTokenTable($token)
	{
		$query = "INSERT INTO `Tokens` (Token) VALUES('".$token."')";
		try
		{
			$retval = mysql_query($query);
			return $this->JSONResponse(0, MESSAGE_0, "");
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}	
	}
	
	public function IsValidToken($token)
	{
		$query = "Select * from `Tokens` where Token = '".$token."'";
		try
		{
			$retval = mysql_query($query);
			return (mysql_num_rows($retval) === 1)?"True":"False";
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}
		
	}
	
	public function IsValidUsername($uname)
	{
		$query = "Select * from `User` where Username = '".$uname."'";
		try
		{
			$retval = mysql_query($query);
			return (mysql_num_rows($retval) === 1)?"True":"False";
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}		
	}
	
	public function CreateUser($uname)
	{
		$query = "INSERT INTO `User` (Username) VALUES('".$uname."')";
		try
		{
			$retval = mysql_query($query);
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}		
	}
	
	public function GetUserData($uname)
	{
		$query = "Select Data from `User` where Username = '".$uname."'";
		try
		{
			$retval = mysql_query($query);
			$result = new stdClass;
			while ($row = mysql_fetch_array($retval)) 
			{
				$result->Data =$row['Data'];				
			}
			return $this->JSONResponse(0, MESSAGE_0, $result);
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}
		
	}
	
	public function ValidateTokenFromUserTable($token)
	{
		$query = "Select * from `User` where Token = '".$token."'";
		try
		{
			$retval = mysql_query($query);
			return (mysql_num_rows($retval) === 1)?"True":"False";
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}		
	}
	
	
	public function AssociateUserAndToken($token, $user)
	{
		$query = "UPDATE  `User` SET Token =  '".$token."' WHERE Username =  '".$user."'";
		try
		{
			$retval = mysql_query($query);			
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}
		$query = "Select * from `User` where Token = '".$token."'";
		$array = new stdClass;
		try
		{
			$retval = mysql_query($query);
			while ($row = mysql_fetch_array($retval)) 
			{
				$array->PreTreatmentSurvey =  $row['PreTreatmentSurvey'];
				$array->PostTreatmentSurvey =  $row['PostTreatmentSurvey'];
				break;
			}		
			return json_encode($array);
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}
	}
	
	public function GetUserDataForLevel($user, $level)
	{
		$query = "Select Level".$level." from `User` where Username = '".$user."'";
		try
		{
			$retval = mysql_query($query);
			while ($row = mysql_fetch_array($retval)) 
			{
				return $row['Level'.$level];
			}
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}		
	}
	
	public function AddTrackingDataToUserData($token, $level, $rating)
	{
		$query = "Select Level".$level." from `User` where Token = '".$token."'";
		//fetch existing data
		try
		{
			$retval = mysql_query($query);
			while ($row = mysql_fetch_array($retval)) 
			{
				$levelData = $row['Level'.$level];
				break;
			}
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}
		
		// add new data to existing data 
		$levelData = $levelData."\n".$rating.",".date("Y-m-d h:i");
		try
		{
			$query = "UPDATE  `User` SET Level".$level." =  '".$levelData."' WHERE Token =  '".$token."'";
			$retval = mysql_query($query);
		}
		catch (Exception $ex) 
		{	
			return $this->JSONResponse(501, MESSAGE_501, $ex);
		}	
		
	}
	
	public function JSONResponse($code, $message, $data)
	{
		$result = new stdClass;
		$result->code = $code;
		$result->message = $message;
		$result->data = $data;		
		return json_encode($result);
	}
}
?>