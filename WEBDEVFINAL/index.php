<?php
session_start();
include_once 'inc/functions.php';
$user = new User();

if ($_SERVER["REQUEST_METHOD"] == "POST") 
{ 
$login = $user->check_login($_POST['username'], $_POST['password']);
if ($login) 
{
// Login Success
header("location:home.php");
} 
else 
{
// Login Failed
header("location:error.php");
}
}
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>WEBDEVT FINAL PROJECT</title>
<link href="main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 65px;
            text-align: right;
        }
        .style2
        {
            width: 65px;
            text-align: right;
            height: 18px;
        }
        .style3
        {
            height: 18px;
        }
    </style>
</head>
<body>
<div id="jayc_container_wrapper">
<div id="jayc_container">
	<div id="jayc_banner">
	  <div id="site_title">
            <h1><a href="#"></span></a><a href="#"><img src="images/jayc.png" width="176" height="58" /></a></h1>
  </div>
        
        <div id="jayc_menu">
          
		</div> <!-- end of menu -->
    
    </div> <!-- end of banner -->
    
    <div id="jayc_content">
    	
        <div id="side_column">
        </div> <!-- end of side column -->
        
        <div id="main_column">
        
            <div class="main_column_section">       
            
                <h2>Login</h2>
                
                <div class="main_column_section_content">
                
                    <div> 
                        <p>
                            <form action="" method="post" name="login">
                            <table style="width:61%;">
                                <tr>
                                    <td class="style1">
                                        Username:</td>
                                    <td>
                      <input type="text" name="username" required/></td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Password:</td>
                                    <td>
                        <input type="password" name="password" required/></td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        &nbsp;</td>
                                    <td>
                                        <br />
                                        <input type="submit" name="submit" value="Login" /></td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        </td>
                                    <td class="style3">
                                        <br />
                    Don't have an account? Click <a href="register.php">here</a> to register.
                                    </td>
                                </tr>
                            </table>
                        </form>
                      </p>
                  </div>
                  </div>
              <div class="cleaner"></div>
                <div class="bottom"></div>
            </div>
            
            
    
    	<div class="cleaner"></div>
    </div> <!-- end of content -->
    
    <div id="jayc_footer">
    
    <div id="jayc_footer_bar">
    
        Copyright © 2013 <a href="#">MIKE</a></div>
    
    </div> <!-- end of footer -->

</div> <!-- end of container -->
</div> <!-- end of container wrapper -->
</body>
</html>
