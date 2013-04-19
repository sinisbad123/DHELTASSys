<?php
include_once 'config.php';
define('DB_SERVER', 'localhost');
define('DB_USERNAME', 'root');
define('DB_PASSWORD', '');
define('DB_DATABASE', 'cmanagement');
class User
{
	public function __construct() 
	{
		$connection = mysql_connect(DB_SERVER, DB_USERNAME, DB_PASSWORD) or 
		die('Oops connection error -> ' . mysql_error());
		mysql_select_db(DB_DATABASE, $connection) 
		or die('Database error -> ' . mysql_error());
	}
	public function register_user($name, $username, $password, $email) 
	{
		$password = md5($password);
		$sql = mysql_query("SELECT uid from users WHERE username = '$username' or email = '$email'");
		$no_rows = mysql_num_rows($sql);
		if ($no_rows == 0) 
		{
			$result = mysql_query("INSERT INTO users(username, password, name, email) values ('$username','$password','$name','$email')") or die(mysql_error());
			return $result;
		}
		else
		{
			return FALSE;
		}
	}
	public function check_login($emailusername, $password) 
	{
		$password = md5($password);
		$result = mysql_query("SELECT uid from users WHERE email = '$emailusername' or username='$emailusername' and password = '$password'");
		$user_data = mysql_fetch_array($result);
		$no_rows = mysql_num_rows($result);
		if ($no_rows == 1) 
		{
			$_SESSION['login'] = true;
			$_SESSION['uid'] = $user_data['uid'];
			return TRUE;
		}
		else
		{
			return FALSE;
		}
	}
	public function get_fullname($uid) 
	{
		$result = mysql_query("SELECT name FROM users WHERE uid = $uid");
		$user_data = mysql_fetch_array($result);
		echo $user_data['name'];
	}
	public function create_article($title, $uid, $category, $article)
	{
		$result = mysql_query("INSERT INTO tblarticle(title, uid, category, article, datetime) values ('$title','$uid','$category','$article',now())") or die(mysql_error());
		return $result;
	}
	public function update_article($title, $uid, $category, $article, $articleid)
	{
		$result = mysql_query("UPDATE tblarticle SET title='$title', uid='$uid', category='$category', article='$article', datetime=now() WHERE articleid='$articleid'") or die(mysql_error());
		return $result;
	}
	public function view_commentz($articleid)
	{
		mysql_connect("localhost", "root", "") or die(mysql_error()); 
 		mysql_select_db("cmanagement") or die(mysql_error()); 
		$result = mysql_query("SELECT * FROM tblcomments INNER JOIN tblarticle ON tblcomments.articleid = tblarticle.articleid INNER JOIN users ON tblcomments.uid = users.uid WHERE tblarticle.articleid = '$articleid' ORDER BY tblcomments.datetime ASC") or die(mysql_error());
		$num = mysql_numrows($result);
		mysql_close();
		$i=0;
		echo "<center>--Comment Section--</center>";
		echo "<hr>";
		while ($i < $num) 
		{
			$username = mysql_result($result,$i,"username");
			$datetime = mysql_result($result,$i,"tblcomments.datetime");
			$comment = mysql_result($result,$i,"tblcomments.comment");

			echo "<strong>$username</strong>: $comment<br>
			on $datetime<br> <hr>";
			$i++;
		}
	}
	
	public function view_article() 
	{
		mysql_connect("localhost", "root", "") or die(mysql_error()); 
 		mysql_select_db("cmanagement") or die(mysql_error()); 
		$result = mysql_query("SELECT * FROM tblarticle LEFT JOIN users ON tblarticle.uid = users.uid  ORDER BY datetime DESC") or die(mysql_error());
		$num = mysql_numrows($result);
		mysql_close();
		$i = 0;
		
		while ($i < $num) 
		{
			$articleid = mysql_result($result,$i,"articleid");
			$title = mysql_result($result,$i,"title");
			$username = mysql_result($result,$i,"username");
			$category = mysql_result($result,$i,"category");
			$date = mysql_result($result,$i,"datetime");
			$article = mysql_result($result,$i,"article");
			echo "	<a href=\"comment.php?id=$articleid\"><h1>$title</h1></a><br>";
			echo "	By <strong>$username</strong> on $date<br>";
			echo "	Category: <strong>$category</strong><br>";
			echo "	<p>$article</p>";	
			echo "	<hr><br>";
			$i++;
		}
	}

	public function view_article2($articleid) 
	{
		$result = mysql_query("SELECT * FROM tblarticle LEFT JOIN users ON tblarticle.uid = users.uid WHERE tblarticle.articleid = '$articleid' ORDER BY datetime DESC") or die(mysql_error());
		$row = mysql_fetch_array($result);
		mysql_close();
		
		$title = $row['title'];
		$usersid = $row['uid'];
		$username = $row['username'];
		$category = $row['category'];
		$datetime = $row['datetime'];
		$article = $row['article'];
		echo "	<h1>$title</h1><br>";
		echo "	By <strong>$username</strong> on $datetime<br>";
		echo "	Category: <strong>$category</strong><br>";
		echo "	<p>$article</p>";	
		echo "	<br>";
	}

	public function view_category() 
	{
		$result = mysql_query("SELECT category FROM tblarticle GROUP BY category") or die(mysql_error());
		$num = mysql_numrows($result);
		mysql_close();
		$i = 0;
		
		while ($i < $num) 
		{
			$category = mysql_result($result,$i,"category");
			echo "<a href=\"category.php?id=$category\">$category<br></a>";
			$i++;
		}
	}

	public function view_bycategory($category) 
	{
		mysql_connect("localhost", "root", "") or die(mysql_error()); 
 		mysql_select_db("cmanagement") or die(mysql_error()); 
		$result = mysql_query("SELECT * FROM tblarticle LEFT JOIN users ON tblarticle.uid = users.uid WHERE tblarticle.category = '$category' ORDER BY datetime DESC") or die(mysql_error());
		$num = mysql_numrows($result);
		mysql_close();
		$i = 0;
		
		while ($i < $num) 
		{
			$articleid = mysql_result($result,$i,"articleid");
			$title = mysql_result($result,$i,"title");
			$username = mysql_result($result,$i,"username");
			$category = mysql_result($result,$i,"category");
			$date = mysql_result($result,$i,"datetime");
			$article = mysql_result($result,$i,"article");
			echo "	<a href=\"comment.php?id=$articleid\"><h1>$title</h1></a><br>";
			echo "	By <strong>$username</strong> on $date<br>";
			echo "	Category: <strong>$category</strong><br>";
			echo "	<p>$article</p>";	
			echo "	<hr><br>";
			$i++;
		}
	}

	public function view_article_title($uid) 
	{
		$result = mysql_query("SELECT * FROM tblarticle INNER JOIN users ON tblarticle.uid=users.uid WHERE users.uid = '$uid'");
		$row=mysql_fetch_array($result);
		echo '<option value="'.$row['articleid'].'">'.$row['title'].'</option>';
		while ($row = mysql_fetch_array($result)) 
		{
			echo '<option value="'.$row['articleid'].'">'.$row['title'].'</option>';
		}
	}
	public function comment($uid, $comment, $articleid)
	{
		$result = mysql_query("INSERT INTO tblcomments(uid, comment, articleid, datetime) values ('$uid','$comment','$articleid',now())") or die(mysql_error());
		return $result;
	}
}
?>