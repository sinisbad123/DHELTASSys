<?php
include_once 'inc/functions.php';
$user = new User();
if ($_SERVER["REQUEST_METHOD"] == "POST") 
{
    $register = $user->register_user($_POST['name'], $_POST['username'], $_POST['password'], $_POST['email']);
    if ($register) 
    {
        // Registration Success
        header("location:reged.php");
    } 
    else 
    {
        // Registration Failed
        header("location:regbad.php");
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
            width: 111px;
            text-align: right;
        }
        #Select1
        {
            width: 128px;
        }
        .style2
        {
            width: 111px;
            height: 22px;
            text-align: right;
        }
        .style3
        {
            height: 22px;
        }
        #Select2
        {
            width: 48px;
        }
        #Select3
        {
            width: 48px;
        }
        #Select4
        {
            width: 48px;
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
            
                <h2>Register</h2>
                
                <div class="main_column_section_content">
                
                    <div>
                    <p>
                        <form action="" method="post" name="reg">
                        <table style="width:51%;">
                            <tr>
                                <td class="style1">
                                    Username:</td>
                                <td>
                      <input type="text" name="username" required /></td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    Password:</td>
                                <td>
                      <input type="password" name="password" required /></td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    Full Name:</td>
                                <td>
                      <input type="text" name="name" required /></td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    Email:</td>
                                <td>
                      <input type="email" name="email" required /></td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td class="style3">
                                    <br />
                        <input type="submit" name="btnRegister" value="Register"/></td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td class="style3">
                                    <br />
                                    Click <a href="index.php">here</a> to go back.
                                </td>
                            </tr>
                        </table>
                    </form>
                        </p>
                  </div>
                  </div>
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
