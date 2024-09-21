<?php
	chdir("./patches/");
	foreach (glob("*", GLOB_ONLYDIR) as $filename) {
		echo "$filename\n";
	}
?>