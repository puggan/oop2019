<?php
declare(strict_types=1);

use Puggan\Oop2019\Console;

require_once __DIR__ . '/../vendor/autoload.php';

define('MIN', 0);
define('MAX', 100);

function takeGuess(int $min, int $max): int
{
    while (true) {
        $number = Console::ReadInt('Guess a number');
        if ($number < $min) {
            Console::ErrorWriteLine('You already know the number is greater then ' . ($min - 1));
            continue;
        }

        if ($number > $max) {
            Console::ErrorWriteLine('You already know the number is lesser then ' . ($max + 1));
            continue;
        }

        return $number;
    }
}

$points = 0;
$min = MIN;
$max = MAX;
$goal = random_int(MIN, MAX);
$guess = MAX + 1;
echo "The hidden number is between {$min} and {$max}.", PHP_EOL;

while ($guess !== $goal) {
    $points++;
    if ($points % 2) {
        $guess = takeGuess($min, $max);
    } else {
        $guess = ($min + $max) >> 1;
        echo "The opponent guesses: {$guess}.", PHP_EOL;
    }
    if ($guess < $goal) {
        echo "The hidden number is greater then {$guess}.", PHP_EOL;
        $min = $guess + 1;
    } elseif ($guess > $goal) {
        echo "The hidden number is lesser then {$guess}.", PHP_EOL;
        $max = $guess - 1;
    }
}

if ($points % 2) {
    echo "Good jobb, you solved it in {$points} tries.", PHP_EOL;
} else {
    echo "Bad luck, opponent solved it on the {$points} round.", PHP_EOL;
}

