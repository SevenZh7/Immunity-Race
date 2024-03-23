import argparse

def parse_arguments():
    """Parse command line arguments using argparse."""
    parser = argparse.ArgumentParser(description='MIPS Assembly to Machine Code Parser')
    parser.add_argument('--file', required=True, help='Input file containing MIPS assembly code')
    return parser.parse_args()

def convert_to_machine_code(opcode, args):
    """Convert MIPS assembly instruction to 32-bit machine code."""
    # Dictionary to map opcodes to their corresponding binary representations
    opcode_mapping = {
        'add': '000000', 'sub': '000000', 'sll': '000000', 'srl': '000000', 'slt': '000000',
        'addi': '001000', 'beq': '000100', 'bne': '000101', 'lw': '100011', 'sw': '101011'
    }

    # Function to convert a register or immediate value to 5-bit binary
    def convert_to_binary(value, is_register=True):
        if is_register:
            return format(int(value[1:]) if value[1:].isdigit() else register_aliases[value[1:]], '05b')
        else:
            return format(int(value), '016b')

    # Check if opcode is valid
    if opcode not in opcode_mapping:
        return '!!! Invalid Input !!!'

    # Constructing the 32-bit machine code based on instruction type
    machine_code = opcode_mapping[opcode]
    
    if opcode in ['add', 'sub', 'sll', 'srl', 'slt']:
        # R-type instructions
        _, rd, rs, rt = args.split(',')
        machine_code += convert_to_binary(rs) + convert_to_binary(rt) + convert_to_binary(rd) + '00000' + '000000'
    
    elif opcode in ['addi', 'beq', 'bne']:
        # I-type instructions
        _, rs, rt, imm = args.split(',')
        machine_code += convert_to_binary(rs) + convert_to_binary(rt) + convert_to_binary(imm, False)
    
    elif opcode in ['lw', 'sw']:
        # I-type load/store instructions
        _, rt, offset_rs = args.split(',')
        offset, rs = offset_rs.split('(')
        machine_code += convert_to_binary(rs) + convert_to_binary(rt) + convert_to_binary(offset, False)

    return machine_code

def main():
    args = parse_arguments()
    
    with open(args.file, 'r') as input_file, open('out_code.txt', 'w') as output_file:
        for line in input_file:
            line = line.strip()
            if line:  # Ignore empty lines
                try:
                    opcode, args = line.split(maxsplit=1)
                    machine_code = convert_to_machine_code(opcode, args)
                    output_file.write(machine_code + '\n')
                except (ValueError, IndexError):
                    output_file.write('!!! Invalid Input !!!\n')
                    break

if __name__ == '__main__':
    main()