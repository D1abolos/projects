<?php 
header("Content-Type: text/html; charset=utf-8"); 
session_start();
if ($_SESSION['send'] == $_SERVER['REMOTE_ADDR'])  
{
	
}