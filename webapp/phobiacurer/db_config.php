<?php
$user="root";
$password="";
$database="PhobiaCurer";

@mysql_connect(localhost,$user,$password);
@mysql_select_db($database) or die("Unable to select database");
?>