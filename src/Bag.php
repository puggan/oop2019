<?php
declare(strict_types=1);

namespace Puggan\Oop2019;

Class Bag implements \IteratorAggregate
{
    private $template;
    private $list;

    public function __construct($list)
    {
        $this->template = $list;
        $this->reset();
    }

    private function reset()
    {
        $this->list = $this->template;
        /** @noinspection NonSecureShuffleUsageInspection */
        shuffle($this->list);
    }

    public function next()
    {
        if (!$this->list) {
            $this->reset();
        }
        return array_pop($this->list);
    }

    public function getIterator()
    {
        while(true) {
            yield $this->next();
        }
    }
}
