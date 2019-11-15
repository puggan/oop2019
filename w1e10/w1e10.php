<?php
declare(strict_types=1);

use Puggan\Oop2019\Console;

require_once __DIR__ . '/../vendor/autoload.php';

class Invader
{
    /** @var string[] */
    private $mask;
    /** @var int */
    public $height;
    /** @var int */
    public $width;

    public function __construct()
    {
        /** @var int[][] $bits */
        $bits = json_decode(file_get_contents(__DIR__ . '/invader.json'), false, 512, JSON_THROW_ON_ERROR);
        /**
         * @param int $bit
         * @return string
         */
        $onoff = static function($bit) {
            return $bit ? '**' : '  ';
        };
        $this->height = count($bits);
        $this->width = count($bits[0])*2;
        $this->mask = array_map(
            static function ($row) use ($onoff) {
                return implode('', array_map($onoff, $row));
            },
            $bits
        );
    }
    public function print($left, $top)
    {
        foreach (range(0, $this->height - 1) as $rownr) {
            Console::SetCursorPosition($left, $top + $rownr);
            echo $this->mask[$rownr];
        }
        echo PHP_EOL;
    }
}

$invader = new Invader();
[$sizex, $sizey] = Console::Size();

foreach(range(0, $sizey - 1) as $posy)
{
    $maxx = $sizex - 1 - $invader->width;
    if ($posy & 1) {
        $steps = range($maxx, 0, -1);
    } else {
        $steps = range(0, $maxx);
    }
    foreach($steps as $posx) {
        Console::Clear();
        $invader->print($posx, $posy);
        usleep(100000);
    }
}
