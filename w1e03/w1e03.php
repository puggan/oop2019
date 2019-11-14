<?php
declare(strict_types=1);

function IsPalindrome(string $text): bool
{
    /** @var string $noSpaceText */
    $noSpaceText = preg_replace('/\s+/', '', strtolower($text));
    $length = strlen($noSpaceText);
    // 5/2 = 2.5 = a float, 5 >> 1 = 2 = a int, range(0, float) = float[], range(0, int) = int[], string[float] => warnings
    foreach (range(0, $length >> 1) as $position) {
        if ($noSpaceText[$position] !== $noSpaceText[$length - 1 - $position]) {
            return false;
        }
    }
    return true;
}

foreach (array_slice($argv, 1) as $arg) {
    if (IsPalindrome($arg)) {
        echo '✔ ', $arg, PHP_EOL;
    } else {
        echo '❌ ', $arg, PHP_EOL;
    }
}
