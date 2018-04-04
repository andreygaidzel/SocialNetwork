export const searchDelay = (function ()
{
  let delayTimer;
  return function (func, delay)
  {
    clearTimeout(delayTimer);
    delayTimer = setTimeout(func, delay);
  };
})();
