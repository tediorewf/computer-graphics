#ifndef OBJ_PARSER_H
#define OBJ_PARSER_H

#include "Vertex.h"

#include <string>
#include <vector>

std::vector<Vertex> parse_obj(const std::string &filename);

#endif // !OBJ_PARSER_H
