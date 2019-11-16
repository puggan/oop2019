<?php
declare(strict_types=1);

use Puggan\Oop2019\Console;

require_once __DIR__ . '/../vendor/autoload.php';

(static function () {
    $firstYear = Console::ReadInt('First year');
    $lastYear = Console::ReadInt('Last year');

    if ($lastYear < $firstYear) {
        Console::ErrorWriteLine('Backwards counting not supported');
        return;
    }

    if ($firstYear < 1582) {
        Console::ErrorWriteLine(
            "Can't calculate leap-years before they was invented in the Gregorian calendar at 1582"
        );
        $firstYear = 1582;
    }

    if ($lastYear > 9999) {
        Console::ErrorWriteLine("I'm not sure we going to use the Gregorian calendar for that long...");
        return;
    }

    foreach (range($firstYear, $lastYear) as $year) {
        /** @noinspection SuspiciousBinaryOperationInspection */
        if ($year % 4 > 0 || $year % 100 === 0 && $year % 400 > 0) {
            echo '❌ ', $year, PHP_EOL;
        } else {
            echo '✔ ', $year, PHP_EOL;
        }
    }
})();
