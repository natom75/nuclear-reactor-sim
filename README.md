# Simulated Interacive Nuclear Reactor
## TL:DR
This is a simulaton of a standard RBMK (which is graphite-moderated, water cooled) nuclear fission reactor.

## Parameters
- Type of fuel rods: Pure uranium dioxide or uranium oxide with europium oxide (correlates with the number of fissions each second)
- Spentness of the fuel rods: 0-100% (correlates with the number of fissions each second)
- Enrichment of the fuel rods: 1-20%, ideal is 2% (correlates with the number of fissions each second)
- Percent of graphite rod in the reactors' core per rods: (correlates with the number of fissions each second)
- Number of fissions each second: (correlates with the reactors' temperature)
- Reactors' temperature: (correlates with the circulating waters' temperature)
- Circulating waters' speed: (correlates with the reactors' temperature, the circulating waters' temperature and the final heat output)
- Circulating waters' temperature: (correlates with the reactors' temperature and the final heat output)
- Final heat output: (correlates with the circulating waters' temperature)
- Power output: (correlates with the final heat output)

## Interface
The screen consists of a data page and a control page. The data page consists of 3 sub-pages. In the reactors' data page You can see:
- The reactors' **temperature**
- The control rods' status (**percent of the rod in the reactor, per rod**)
- The **spentness** of the fuel rods
- 
After that, in the cooling systems' data page You can see:
- The circulating waters' **temperature**
- The circulating waters' **speed**
- 
And finally, in the output page You can see:
- The final **heat** output
- The **power** output

## Consequences:
It can work or it can blow up.

## How does it work
I don't know it yet
