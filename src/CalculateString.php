<?php
declare(strict_types=1);

namespace Puggan\Oop2019;

class CalculateString
{
    private $formula;
    private $parts = [];
    private $partValues = [];

    public function __construct(string $formula)
    {
        $this->formula = $formula;
    }

    public function calc(): float
    {
        return $this->parse(
            $this->decode(
                $this->encode(
                    $this->formula
                )
            )
        );
    }

    private function parse(string $part): float
    {
        $pos = strpos($part, '+');
        if ($pos !== false) {
            return $this->parseFront($part, $pos) + $this->parseBack($part, $pos);
        }

        $pos = strpos($part, '-');
        if ($pos !== false) {
            return $this->parseFront($part, $pos) - $this->parseBack($part, $pos);
        }

        $pos = strpos($part, '*');
        if ($pos !== false) {
            return $this->parseFront($part, $pos) * $this->parseBack($part, $pos);
        }

        $pos = strrpos($part, '/');
        if ($pos !== false) {
            return $this->parseFront($part, $pos) / $this->parseBack($part, $pos);
        }

        $pos = strpos($part, '^');
        if ($pos !== false) {
            return $this->parseFront($part, $pos) ** $this->parseBack($part, $pos);
        }

        return +$part;
    }

    private function parseFront($part, $pos)
    {
        return $this->parse(substr($part, 0, $pos));
    }

    private function parseBack($part, $pos)
    {
        return $this->parse(substr($part, 1 + $pos));
    }

    private function decode(string $part): string
    {
        $formula = $part;
        $pattern = '/<#\\w{32}#>/';
        while (preg_match_all($pattern, $formula, $matches, PREG_PATTERN_ORDER)) {
            foreach ($matches[0] as $match) {
                if (!isset($this->partValues[$match])) {
                    $this->partValues[$match] = $this->parse($this->decode($this->parts[$match]));
                }
                $formula = str_replace($match, $this->partValues[$match], $formula);
            }
        }
        return $formula;
    }

    private function encode(string $part): string
    {
        $formula = $part;
        $pattern = '/\\([^\\(\\)]+\\)/';
        while (preg_match_all($pattern, $formula, $matches, PREG_PATTERN_ORDER)) {
            foreach ($matches[0] as $match) {
                $token = '<#' . md5($match) . '#>';
                $this->parts[$token] = substr($match, 1, -1);
                $formula = str_replace($match, $token, $formula);
            }
        }
        return $formula;
    }
}
