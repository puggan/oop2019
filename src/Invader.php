<?php
declare(strict_types=1);

namespace Puggan\Oop2019;

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
        $bits = json_decode(file_get_contents(__DIR__ . '/../data/invader.json'), false, 512, JSON_THROW_ON_ERROR);
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
