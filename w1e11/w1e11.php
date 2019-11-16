<?php
declare(strict_types=1);

use Puggan\Oop2019\CalculateString;

require_once __DIR__ . '/../vendor/autoload.php';

$formula = implode(' ', array_slice($argv, 1));
$result = (new CalculateString($formula))->calc();
echo "{$formula} = {$result}", PHP_EOL;
