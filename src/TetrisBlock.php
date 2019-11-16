<?php
declare(strict_types=1);

namespace Puggan\Oop2019;

use Puggan\Oop2019\Console;

class TetrisBlock
{
    private $pixels;
    private $color;
    private $dir = 0;

    public function __construct(array $pixels, string $color)
    {
        $this->pixels = $pixels;
        $this->color = $color;
    }

    public function RotateCW()
    {
        $this->dir = ($this->dir + 1) % 4;
    }

    public function RotateCCW()
    {
        $this->dir = ($this->dir + 3) % 4;
    }

    private function getRotated()
    {
        switch ($this->dir) {
            case 3:
                return array_reverse(array_map(null, ...$this->pixels));
            case 2:
                return array_reverse(array_map('array_reverse', $this->pixels));
            case 1:
                return array_map(null, ...array_reverse($this->pixels));
            case 0:
            default:
                return $this->pixels;
        }
    }

    public function Print(int $xStart, int $yStart)
    {
        echo $this->color;
        foreach ($this->getRotated() as $y => $row) {
            $restart = true;
            foreach ($row as $x => $bit) {
                if ($bit) {
                    if ($restart) {
                        Console::SetCursorPosition(2 * ($xStart + $x), $yStart + $y);
                        $restart = false;
                    }
                    echo '  ';
                } else {
                    $restart = true;
                }
            }
        }
        Console::ResetColor();
    }
}
