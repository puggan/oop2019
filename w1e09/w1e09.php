<?php
declare(strict_types=1);

//$count = countTypeOnMap(map($argv[0]), '#');
$count = substr_count(file_get_contents($argv[1]), '#');
echo "found {$count}", PHP_EOL;
