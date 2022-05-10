namespace AdventOfCode._2019.Day2;

internal sealed class IntcodeComputer
{
    private int[] _memory;
    private int[] _backupMemory;
    private int _noun = 12;
    private int _verb = 2;

    public int Noun
    {
        get => _noun;
        set
        {
            if (value >= 0 && value <= 99)
            {
                _noun = value;
            }
        }
    }

    public int Verb
    {
        get => _verb;
        set
        {
            if (value >= 0 && value <= 99)
            {
                _verb = value;
            }
        }
    }

    private enum Opcode
    {
        Add = 1,
        Multiply = 2,
        Exit = 99
    }

    public IntcodeComputer(int[] IntcodeProgram)
    {
        _memory = new int[IntcodeProgram.Length];
        IntcodeProgram.CopyTo(_memory, 0);

        _backupMemory = new int[_memory.Length];
        _memory.CopyTo(_backupMemory, 0);
    }

    public int ValueAt(int address)
    {
        if (address >= 0 && address < _memory.Length)
        {
            return _memory[address];
        }
        else
        {
            throw new ArgumentException("Wrong memory address");
        }
    }

    public void RestoreGravityAssistProgram()
    {
        int instructionPointer = 0;
        Opcode opcode = (Opcode)_memory[instructionPointer];

        while (opcode is not Opcode.Exit)
        {
            if (opcode is Opcode.Add)
            {
                (int, int, int) parameters = GetParameters(instructionPointer);
                Add(parameters.Item1, parameters.Item2, parameters.Item3);
            }
            else if (opcode is Opcode.Multiply)
            {
                (int, int, int) parameters = GetParameters(instructionPointer);
                Multiply(parameters.Item1, parameters.Item2, parameters.Item3);
            }
            else
            {
                throw new ArgumentException("Invalid opcode");
            }

            instructionPointer += 4;
            opcode = (Opcode)_memory[instructionPointer];
        }
    }

    public void PrepareProgram()
    {
        _memory[1] = _noun;
        _memory[2] = _verb;
    }

    public void RestoreToDefault()
    {
        _backupMemory.CopyTo(_memory, 0);
    }

    private (int, int, int) GetParameters(int address)
    {
        int leftElement = _memory[address + 1];
        int rightElement = _memory[address + 2];
        int result = _memory[address + 3];

        return (leftElement, rightElement, result);
    }

    private void Add(int leftElementAddress, int rightElementAddress, int resultAddress)
    {
        _memory[resultAddress] = _memory[leftElementAddress] + _memory[rightElementAddress];
    }

    private void Multiply(int leftElementAddress, int rightElementAddress, int resultAddress)
    {
        _memory[resultAddress] = _memory[leftElementAddress] * _memory[rightElementAddress];
    }
}
