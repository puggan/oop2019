<?php
declare(strict_types=1);

define('FROM', 1);
define('TO', 100);
define('FIZZ', 3);
define('BUZZ', 5);

foreach (range(FROM, TO) as $number) {
    $found = false;
    if ($number % FIZZ === 0) {
        echo 'Fizz';
        $found = true;
    }
    if ($number % BUZZ === 0) {
        echo 'Buzz';
        $found = true;
    }

    echo $found ? '' : $number, PHP_EOL;
}
